using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MXM.Infrastructure.Services.ReturnPadraoServices.InterfacesServicoPadrao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MXM.Infrastructure.Services.ReturnPadraoServices
{
    public static class ProcessoRespostaRestExtension
    {
        public static IActionResult Retornar(this ServicoRetornoPadrao servico, ControllerBase controller, string linkDoResource = null)
        {
            var retorno = new { servico.Retorno, servico.Mensagens };

            //qualquer serviço com erro de validação
            if (servico.Mensagens.TemErros())
            {
                //indepententemente do tipo, se tem mensagem de erro retorna 400 - bad request - erro de validação
                return controller.BadRequest(retorno);
            }

            //get/id, put ou delete onde o recurso não foi encontrado
            var servicoComBuscaPadrao = servico as IServicoComBuscaPadrao;
            if (servicoComBuscaPadrao != null && !servicoComBuscaPadrao.Encontrado)
            {
                //se o recurso não foi encontrado, retorno not found
                return controller.NotFound(retorno);
            }

            //Não considero o 500 - se ocorrer exceção não tratada, o ideal é logar e deixar propagar - o próprio .net retorna 500 nesse caso

            //post ou put
            var servicoDeGravacaoPadrao = servico as IServicoDeGravacaoPadrao;
            if (servicoDeGravacaoPadrao != null)
            {
                //Se foi criado um novo registro (padrão do post, mas possível no put) e se foi passado o link do resource
                if (servicoDeGravacaoPadrao.IdentificadorDoRegistroCriado != null && !string.IsNullOrWhiteSpace(linkDoResource))
                {
                    //retorna 201 com o link - inserido com sucesso + link para recurso criado
                    return controller.Created(linkDoResource + "/" + servicoDeGravacaoPadrao.IdentificadorDoRegistroCriado, retorno);
                }

                // padrão do put - sem conteúdo
                if (retorno == null && (retorno.Mensagens == null || !retorno.Mensagens.Any()))
                {
                    //retorna 204 - atualizado com sucesso
                    return controller.NoContent();
                }
            }

            var servicoDeExclusaoPadrao = servico as IServicoDeExclusaoPadrao;
            if (servicoDeExclusaoPadrao != null)
            {
                // padrão do delete - sem conteúdo
                if (retorno == null && (retorno.Mensagens == null || !retorno.Mensagens.Any()))
                {
                    //retorna 204 - excluído com sucesso
                    return controller.NoContent();
                }
            }

            //genérico - retorna ok com o conteúdo, mas sem um código específico
            return controller.Ok(retorno);
        }

    }
}
