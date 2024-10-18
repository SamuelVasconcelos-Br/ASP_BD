using AppQuinto.Models;
using AppQuinto.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppQuinto.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySQL;

        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update cliente set NomeCli=@NomeCli, Endereco=@Endereco," +
                                                    "NumEnd=@NumEnd, Situacao=@Situacao Where IdCli=@IdCli", conexao);

                cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cliente.NomeCli;
                cmd.Parameters.Add("@Endereco", MySqlDbType.VarChar).Value = cliente.Endereco;
                cmd.Parameters.Add("@NumEnd", MySqlDbType.VarChar).Value = cliente.Numero.ToString();
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = cliente.Situacao;
                cmd.Parameters.Add("@IdCli", MySqlDbType.VarChar).Value = cliente.IdCli;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into cliente(NomeCli, Endereco, NumEnd, Situacao) " +
                                                    " values (@NomeCli, @Endereco, @NumEnd, @Situacao)", conexao);

                cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cliente.NomeCli;
                cmd.Parameters.Add("@Endereco", MySqlDbType.VarChar).Value = cliente.Endereco;
                cmd.Parameters.Add("@NumEnd", MySqlDbType.VarChar).Value = cliente.Numero.ToString();
                cmd.Parameters.Add("@Situacao", MySqlDbType.VarChar).Value = cliente.Situacao;

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from cliente where IdCli=@IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Cliente ObterCliente(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from cliente " +
                                                    "where IdCli = @IdCli", conexao);
                cmd.Parameters.AddWithValue("@IdCli", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Cliente cliente = new Cliente();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    cliente.IdCli = Convert.ToInt32(dr["IdCli"]);
                    cliente.NomeCli = (string)dr["NomeCli"];
                    cliente.Endereco = (string)dr["Endereco"];
                    cliente.Numero = Convert.ToInt32(dr["Numero"]);
                    cliente.Situacao = (string)dr["Situacao"];
                }
                return cliente;
            }
        }

            public IEnumerable<Cliente> ObterTodosClientes()
            {
                List<Cliente> ClienteList = new List<Cliente>();
                using (var conexao = new MySqlConnection(_conexaoMySQL))
                {
                    conexao.Open();
                    MySqlCommand cmd = new MySqlCommand("select * from cliente", conexao);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    conexao.Clone();

                    foreach (DataRow dr in dt.Rows)
                    {
                        ClienteList.Add(
                            new Cliente
                            {
                                IdCli = Convert.ToInt32(dr["IdCli"]),
                                NomeCli = (string)dr["NomeCli"],
                                Endereco = (string)dr["Endereco"],
                                Numero = Convert.ToInt32(dr["NumEnd"]),
                                Situacao = (string)dr["Situacao"]
                            });
                    }
                    return ClienteList;
                }
            }
        }
    }

