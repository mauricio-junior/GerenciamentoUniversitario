﻿using BEPiD.Business.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BEPiD.Business.BRL;

namespace BEPiD.Private
{
    public partial class Termo_Outorga : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //HttpCookie Session = Request.Cookies["BEPiDUCB.Site"];

                //if (Session == null || Session["I"].ToString().Equals("0"))
                //{
                //    Response.Redirect("Login");
                //}
                if (Session != null)
                {
                    int idAluno = int.Parse(Request.Params["id"].ToString());

                    AlunoDTO dto = new AlunoDTO();
                    dto.idAluno = idAluno;

                    BEPiD.Business.BRL.AlunoBRL alunoBRL = new Business.BRL.AlunoBRL();
                    DataTable dtAluno = alunoBRL.searchDadosPrincipais(dto);

                    if (dtAluno != null && dtAluno.Rows.Count > 0)
                    {
                        Session.Add("Endereco", dtAluno.Rows[0]["endereco"].ToString());
                        Session.Add("Cidade", dtAluno.Rows[0]["cidade"].ToString());
                        Session.Add("Identidade", dtAluno.Rows[0]["Identidade"].ToString());
                        Session.Add("Orgao", dtAluno.Rows[0]["orgao"].ToString());
                        Session.Add("Nacionalidade", dtAluno.Rows[0]["Nacionalidade"].ToString());
                        Session.Add("EstadoCivil", dtAluno.Rows[0]["EstadoCivil"].ToString());
                        Session.Add("Curso", dtAluno.Rows[0]["Curso"].ToString());
                        Session.Add("NomeUniversidade", dtAluno.Rows[0]["NomeUniversidade"].ToString());
                        Session.Add("N", dtAluno.Rows[0]["Nome"].ToString());
                        Session.Add("C", dtAluno.Rows[0]["CPF"].ToString());

                        gerarWord(sender, e);
                    }
                }
            }

            
        }

        protected void cmdImprimir_Click(object sender, EventArgs e)
        {
            try
            {

                HttpCookie Session = Request.Cookies["BEPiDUCB.Site"];

                AlunoDTO dto = new AlunoDTO();
                dto.idAluno = int.Parse(Session["I"].ToString());
                dto.aceiteTermo = "S";

                AlunoBRL brl = new AlunoBRL();
                brl.updateAlunoAceiteTermo(dto);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void gerarWord(object sender, EventArgs e)
        {
            //HttpCookie Session = Request.Cookies["BEPiDUCB.Site"];

          

            Response.Clear();
            Response.Buffer = true;
            Response.ContentType = "application/msword";
            Response.AddHeader("content-disposition", "attachment;filename=" + Session["N"].ToString() + ".doc");
            Response.Charset = "";
            this.EnableViewState = false;
            System.IO.StringWriter os = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter oh = new HtmlTextWriter(os);
            Response.Write(os);

        }
    }
}