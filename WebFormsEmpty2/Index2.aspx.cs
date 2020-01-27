﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsEmpty2.Implementation;
using WebFormsEmpty2.Interfaces;
using WebFormsEmpty2.Models;

namespace WebFormsEmpty2
{
    public partial class Index2 : System.Web.UI.Page
    {
        private readonly IMultyService<Country> countryService;

        public Index2()
        {
            //countryService = new CountryService();
            //countryService = new CountryServiceDB();
            countryService = new CountryServiceDapper();
            //countryService = new CountryServiceEF();

        }
        protected void Page_Load(object sender, EventArgs e)
        {

            //countryService.Add(new Country() { Name="England", Capital = "London"});
            //countryService.Delete(4);
            GV_Refresh();

            //Response.Write(Request.QueryString[0]);
            //Response.Write(Request.Params[1]);

        }

        void GV_Refresh()
        {
            //GV.DataSource = Repos.Repo;
            cbCountries.DataTextField = "Name";
            cbCountries.DataValueField = "Id";
            cbCountries.DataSource = countryService.getAll_1();
            cbCountries.DataBind();
            GV.DataSource = countryService.getAll_1();
            GV.DataBind();
        }

        protected void btAdd_Click(object sender, EventArgs e)
        {
            countryService.Add(new Country() { Name = tbCountryName.Text, Capital = tbCountryCapital.Text });
            GV_Refresh();
        }

        protected void GV_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GV.PageIndex = e.NewPageIndex;
            GV.DataBind();
        }

        protected void GV_SelectedIndexChanged(object sender, EventArgs e)
        {
            hfCountryId.Value = GV.DataKeys[Convert.ToInt32(GV.SelectedIndex)].Values[0].ToString();
            tbCountryName.Text = GV.DataKeys[Convert.ToInt32(GV.SelectedIndex)].Values[1].ToString();
            tbCountryCapital.Text = GV.DataKeys[Convert.ToInt32(GV.SelectedIndex)].Values[2].ToString();

        }

        protected void btUpd_Click(object sender, EventArgs e)
        {
            countryService.Update_1(new Country() { Name = tbCountryName.Text, Capital = tbCountryCapital.Text, Id = Convert.ToInt32(hfCountryId.Value) });
            GV_Refresh();
        }

        protected void cbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }
    }
}