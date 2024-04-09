using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistema_teste.Data.Context;
using sistema_teste.Domain.Entities.Alunos;
using sistema_teste.UI.Models;
using sistema_teste.UI.Models.Account;

namespace sistema_teste.UI.Controllers
{
    public class AlunosController : Controller
    {
        private readonly DataContext _dbContext;

        public AlunosController(DataContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IActionResult> Index()
        {

            //var consulta = (from usuarios in _dbContext.Usuarios
            //                join alunos in _dbContext.Alunos on usuarios.Id equals alunos.UserId
            //                join tipoPl in _dbContext.TipoPlano on alunos.TipoPlanoId equals tipoPl.Id
            //                join tipoPg in _dbContext.TipoPagamento on alunos.TipoPagamentoId equals tipoPg.Id
            //                join tipoPlPc in _dbContext.TipoPagamentoPc on tipoPg.IdTipoPagamento equals tipoPlPc.Id
            //                select usuarios).ToList();
            //string strSql = string.Format(@"SELECT
            //                        C.Id,
            //                        B.Foto,
            //                        A.NomeCompleto,
            //                        B.Ativo,
            //                        C.DescTipoPlano,
            //                        E.Tipo,
            //                        B.DataInicio,
            //                        B.DataFim
            //                        FROM AspNetUsers A
            //                        INNER JOIN Alunos B ON A.Id = B.UserId
            //                        INNER JOIN TipoPlano C ON B.TipoPlanoId = C.Id
            //                        INNER JOIN TipoPagamento D ON B.TipoPagamentoId = D.Id
            //                        INNER JOIN TipoPagamentoPc E ON D.IdTipoPagamento= E.Id
            //                        ");
            //var resultado = _dbContext.AlunosPesquisa.FromSqlRaw(strSql).ToList();



            //var result = _dbContext.Usuarios.Include(x => x.Alunos).Where(x => x.Alunos.FirstOrDefault().UserId == x.Id).ToList();
            //var teste = result.SelectMany(x => x.Alunos);
            //var resultado = _dbContext.Alunos.ToList();

            var query = (from A in _dbContext.Users
                         join B in _dbContext.Alunos on A.Id equals B.UserId
                         join C in _dbContext.TipoPlano on B.TipoPlanoId equals C.Id
                         join D in _dbContext.TipoPagamentos on B.TipoPagamentoId equals D.Id
                         join E in _dbContext.TipoPagamentoPc on D.TipoPagamentoPcId equals E.Id
                         select new
                         {
                             IdAluno = B.Id,
                             NomeCompleto = A.NomeCompleto,
                             Foto = B.Foto,
                             Ativo = B.Ativo,
                             DescTipoPlano = C.DescTipoPlano,
                             Tipo = E.Tipo

                         }).ToList();

            if (query != null)
            {
                ViewBag.Alunos = query;

            }
            return View();

        }

        public async Task<IActionResult> CadastroAlunos()

        {

            var usuarios = _dbContext.Usuarios.ToList().Where(x => x.EmailConfirmed == false);
            ViewBag.Usuario = new SelectList(usuarios.Select(x => new
            {
                x.Id,
                x.NomeCompleto,
            }), "Id", "NomeCompleto");

            var tipoPlano = _dbContext.TipoPlano.ToList();
            ViewBag.TipoPlano = new SelectList(tipoPlano, "Id", "DescTipoPlano");

            var tipoPagamentoPc = _dbContext.TipoPagamentoPc.ToList();
            ViewBag.TipoPagamentoPc = new SelectList(tipoPagamentoPc, "Id", "Tipo");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroAlunos(AlunosViewModel alunosViewModel)
        {
            try
            {
                var model = new EntidadeAlunos
                {
                    UserId = alunosViewModel.UserId,
                    DataInicio = DateTime.Now,
                    DataFim = DateTime.Now,
                    TipoPlanoId = alunosViewModel.TipoPlanoId,
                    TipoPagamentoId = alunosViewModel.TipoPagamentoId,
                    Ativo = true
                };
                await _dbContext.AddAsync(model);
                await _dbContext.SaveChangesAsync();
                TempData["Msg"] = "Alunos cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public async Task<IActionResult> AlterarAlunos(int? Id)
        {
            var alunosUsuario = _dbContext.Alunos.Include("User").Where(x => x.Id == Id);


            var tipoPlano = _dbContext.TipoPlano.ToList();
            ViewBag.TipoPlano = new SelectList(tipoPlano, "Id", "DescTipoPlano");

            var tipoPagamentoPc = _dbContext.TipoPagamentoPc.ToList();
            ViewBag.TipoPagamentoPc = new SelectList(tipoPagamentoPc, "Id", "Tipo");

            var alunosView = new AlunosEdicaoViewModel
            {
                Id = alunosUsuario.FirstOrDefault().Id,
                NomeCompleto = alunosUsuario.FirstOrDefault().User.NomeCompleto,
                DataInicio = alunosUsuario.FirstOrDefault().DataInicio,
                DataFim = alunosUsuario.FirstOrDefault().DataFim,
                TipoPagamentoId = alunosUsuario.FirstOrDefault().TipoPagamentoId,
                TipoPlanoId = alunosUsuario.FirstOrDefault().TipoPlanoId,

            };

            if (alunosUsuario != null)
            {
                return View(alunosView);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AlterarAlunos(AlunosEdicaoViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var alunos = _dbContext.Alunos.FindAsync(model.Id).Result;

                    alunos.TipoPagamentoId = model.TipoPagamentoId;
                    alunos.TipoPlanoId = model.TipoPlanoId;

                    _dbContext.Alunos.Update(alunos);
                    _dbContext.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public async Task<JsonResult> ExcluirAluno(int Id)
        {
            try
            {
                var alunos = _dbContext.Alunos.FindAsync(Id).Result;

                if (alunos != null)
                {
                    var al = new EntidadeAlunos()
                    {
                        Id = alunos.Id
                    };
                    _dbContext.Alunos.Remove(alunos);
                    _dbContext.SaveChanges();

                    return Json(new { sucesso = true, mensagem = "Aluno excluido com sucesso" });
                }
                else
                {
                    return Json(new { sucesso = false, mensagem = "Aluno não exite" });
                }


            }
            catch (Exception ex)
            {

                return Json(new { sucesso = false, mensagem = ex.Message });
            }

        }

    }
}
