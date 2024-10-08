using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services.Description;

namespace Calculadora
{
    public partial class _Default : Page
    {
        //use sua conexão com seu banco de dados
        //substitua seu Data Source, Catalog, User e Password
        string sCon_SQL = @"Data Source=NII\MSSQLSERVER01;Initial Catalog=myprojetos;User ID=nicollas;Password=lala1219";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarHistorico();
            }
        }

        private void CarregarHistorico()
        {
            string sQuery = @"SELECT ID, valueA, valueB, operation, result, DtaRegistration FROM Calculadora WHERE active = 'S'";

            using (SqlConnection conn = new SqlConnection(sCon_SQL))
            {
                try
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(sQuery, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            grd.DataSource = dataTable;
                            grd.DataBind();
                        }
                    }
                }

                catch (Exception ex)
                {
                    string message = $"Ocorreu um erro: {ex.Message.Replace("'", "\\'")}";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
                }
            }
        }

        private void InsertHistorico(string operation, int result)
        {
            string sQuery = @"INSERT INTO Calculadora (valueA, valueB, operation, result, DtaRegistration, active)
                                VALUES (@valueA, @valueB, @operation, @result, GETDATE(), 'S')";

            using (SqlConnection conn = new SqlConnection(sCon_SQL))
            {
                using (SqlCommand command = new SqlCommand(sQuery, conn))
                {
                    command.Parameters.Add("@valueA", SqlDbType.Int).Value = Convert.ToInt32(txtValorA.Text);
                    command.Parameters.Add("@valueB", SqlDbType.Int).Value = Convert.ToInt32(txtValorB.Text);
                    command.Parameters.Add("@operation", SqlDbType.VarChar).Value = operation;
                    command.Parameters.Add("@result", SqlDbType.VarChar).Value = Convert.ToString(result);


                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                    }

                    catch (Exception ex)
                    {
                        string message = $"Ocorreu ao gravar histórico de operações: {ex.Message.Replace("'", "\\'")}";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
                    }
                }
            }
        }

        private void LimparCampos()
        {
            txtValorA.Text = "";
            txtValorB.Text = "";
        }

        protected void lnkSomar_Click(object sender, EventArgs e)
        {
            string operador = "+";
            int valueA = Convert.ToInt32(txtValorA.Text);
            int valueB = Convert.ToInt32(txtValorB.Text);

            int result = valueA + valueB;

            try
            {
                InsertHistorico(operador, result);

                string message = $"O resultado da Conta é: {result}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);

                LimparCampos();
                CarregarHistorico();
            }

            catch (Exception ex)
            {
                string message = $"Ocorreu um erro: {ex.Message.Replace("'", "\\'")}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
            }
        }

        protected void lnkSubtrair_Click(object sender, EventArgs e)
        {
            string operador = "-";
            int valueA = Convert.ToInt32(txtValorA.Text);
            int valueB = Convert.ToInt32(txtValorB.Text);

            int result = valueA - valueB;

            try
            {
                InsertHistorico(operador, result);

                string message = $"O resultado da Conta é: {result}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);

                LimparCampos();
                CarregarHistorico();
            }

            catch (Exception ex)
            {
                string message = $"Ocorreu um erro: {ex.Message.Replace("'", "\\'")}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
            }
        }

        protected void lnkMultiplicar_Click(object sender, EventArgs e)
        {
            string operador = "*";
            int valueA = Convert.ToInt32(txtValorA.Text);
            int valueB = Convert.ToInt32(txtValorB.Text);

            int result = valueA * valueB;

            try
            {
                InsertHistorico(operador, result);

                string message = $"O resultado da Conta é: {result}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);

                LimparCampos();
                CarregarHistorico();
            }

            catch (Exception ex)
            {
                string message = $"Ocorreu um erro: {ex.Message.Replace("'", "\\'")}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
            }
        }

        protected void lnkDividir_Click(object sender, EventArgs e)
        {
            string operador = "÷";
            int valueA = Convert.ToInt32(txtValorA.Text);
            int valueB = Convert.ToInt32(txtValorB.Text);

            if (valueB == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Não é possível dividir por zero.');", true);
                return;
            }

            int result = valueA / valueB;

            try
            {
                InsertHistorico(operador, result);

                string message = $"O resultado da Conta é: {result}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);

                LimparCampos();
                CarregarHistorico();
            }

            catch (Exception ex)
            {
                string message = $"Ocorreu um erro: {ex.Message.Replace("'", "\\'")}";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", $"alert('{message}');", true);
            }
        }
    }
}