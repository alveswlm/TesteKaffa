using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KaffaTestApplication
{
    public partial class CNPJ : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                txtCNPJ.Value = string.Empty;
        }

        protected void btnValidateMask_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateMask())
                    ShowMessage("success", "CNPJ mask is valid.");
                else
                    ShowMessage("error", "CNPJ mask is invalid.");
            }
            catch (Exception ex)
            {
                divErrorMessage.Visible = true;
                spanErrorMessage.InnerText = $"{ex.Message}";
            }
        }

        protected void btnValidateDigits_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateDigits(txtCNPJ.Value))
                    ShowMessage("success", "CNPJ digits is valid.");
                else
                    ShowMessage("error", "CNPJ digits is not valid.");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ValidateMask()
        {
            try
            {
                string cnpj = txtCNPJ.Value;

                if (cnpj.Contains("."))
                {
                    string[] splitCnpj = cnpj.Split('.');

                    if (splitCnpj[0].Length == 2 && splitCnpj[1].Length == 3)
                    {
                        if (splitCnpj[2].Split('/')[0].Length == 3 && splitCnpj[2].Split('/')[1].Split('-')[0].Length == 4 &&
                            splitCnpj[2].Split('/')[1].Split('-')[1].Length == 2)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (cnpj.Length == 14)
                        return true;
                }
            }
            catch
            {
                throw;
            }

            return false;
        }

        public void ShowMessage(string messageType, string messageText)
        {
            try
            {
                if(messageType == "success")
                {
                    divSuccessMessage.Visible = true;
                    spanSuccessMessage.InnerText = messageText;
                    divErrorMessage.Visible = false;
                }
                else
                {
                    divErrorMessage.Visible = true;
                    spanErrorMessage.InnerText = messageText;
                    divSuccessMessage.Visible = false;
                }
            }
            catch
            {
                throw;
            }
        }

        public bool ValidateDigits(string cnpj)
        {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;
                
                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
                
                if (cnpj.Length != 14)
                    return false;
                
                tempCnpj = cnpj.Substring(0, 12);
                soma = 0;
                
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
                
                resto = (soma % 11);
                
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                
                digito = resto.ToString();
                tempCnpj = tempCnpj + digito;
                soma = 0;
                
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
                
                resto = (soma % 11);
                
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();

                if (cnpj.EndsWith(digito))
                    return true;
            }
            catch
            {
                throw;
            }

            return false;
        }
    }
}