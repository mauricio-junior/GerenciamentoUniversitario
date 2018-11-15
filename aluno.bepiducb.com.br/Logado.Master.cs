﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace aluno.bepiducb.com.br
{
    public partial class Logado : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["NAluno"] == null)
            {
                Response.Redirect("../Login");
            }
        }
    }
}