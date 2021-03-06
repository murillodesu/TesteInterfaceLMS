﻿//-----------------------------------------------------------------------
// <copyright file="ArquivosEdicaoUI.cs" company="LG Sistemas">
//     Copyright © LG Sistemas. All rights reserved.
//     TODOS OS DIREITOS RESERVADOS.
// </copyright>
//-----------------------------------------------------------------------

using System;
using LG.LMS.TestesDeInterface.Infraestrutura;
using LG.LMS.TestesDeInterface.Infraestrutura.PageModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Globalization;
using System.IO;

namespace LG.LMS.TestesDeInterface.PageModel.Administracao.Desenvolvimento.Arquivos
{
    public class ArquivosEdicaoUI : PaginaPadrao
    {
        public ArquivosEdicaoUI(ComponenteDeTela componenteDeTela)
            : base(componenteDeTela)
        {
        }

        [FindsBy(How = How.Id, Using = "titulo")]
        public IWebElement Titulo { get; set; }

        [FindsBy(How = How.Id, Using = "descricao")]
        public IWebElement Descricao { get; set; }

        /// <summary>
        /// Preenche os dados na tela.
        /// </summary>
        /// <param name="model">Os dados para preencher os campos na tela.</param>
        public void PreencheCampoNaTela(ArquivosModel model)
        {
            Titulo.PreencheCampo(model.Titulo);
            Descricao.PreencheCampo(model.Descricao);
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#idioma').val(1).change()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#categoria').val(1).change()");
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#grupo').val(1).change()");
            PreencheArquivo("Arquivo");
        }

        /// <summary>
        /// Click em confirmar na janela modal.
        /// </summary>
        public void CliqueConfirmar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#popup_ok').click()");
        }

        /// <summary>
        /// Click em salvar na janela modal.
        /// </summary>
        public void CliqueSalvar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('#salvar')[0].click()");
        }

        protected override void CarregarPagina()
        {
        }

        public void CliqueCancelar()
        {
            ComponenteDeTela.Script.ExecuteCodigoJavaScript("$('.btn.btn-danger')[0].click()");
        }

        public void PreencheArquivo(string seletor)
        {
            if (ComponenteDeTela.Script.AvalieBooleanJavaScript(String.Format(CultureInfo.InvariantCulture, "$('#{0}').length > 0", seletor)))
            {
                string path = @"\ArquivosParaTeste\LogoLG.jpg";
                path = String.Format(CultureInfo.InvariantCulture, Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + "{0}", path);
                ComponenteDeTela.WebDriver.FindElement(By.Id(seletor)).SendKeys(path);
            }
        }
    }
}
