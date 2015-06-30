using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using System.Data;
using System.Data.SqlClient;

namespace CounterPlay
{
    class BLL
    {
        
        public class users
        {
            //Fazer o login
            static public DataTable Login(string Username, string Password)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Username", Username),
                new SqlParameter("@Password", Password)
                };
                return dal.executarReader("SELECT * FROM Funcionarios WHERE Username=@Username AND Password=@Password", sqlParams);
            }
            //Alterar pass no primeiro Login
            static public int FirstLogin(int IdFuncionario, string Password, bool Login)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdFuncionario", IdFuncionario),
                    new SqlParameter("@Password", Password),
                    new SqlParameter("@Login", Login),
                };
                return dal.executarNonQuery("UPDATE [Funcionarios] SET [Password]=@Password, [Login]=@Login WHERE [IdFuncionario]=@IdFuncionario", sqlParams);
            }
            //Load Completo da Tabela de Funcionarios
            static public DataTable LoadCFuncionarios()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT *  FROM Funcionarios", null);
                              
            }
            //Verificar o Username
            static public DataTable verificarUsername(string Username)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@Username", Username),
            };
                return dal.executarReader("SELECT * FROM Funcionarios WHERE [Username]=@Username", sqlParams);
            }
            //Verificar NIF
            static public DataTable verificarNIF(string NIFFuncionario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@NIFFuncionario", NIFFuncionario),
            };
                return dal.executarReader("SELECT * FROM Funcionarios WHERE [NIFFuncionario]=@NIFFuncionario", sqlParams);
            }
            //Verificar NIF
            static public DataTable verificarNIB(string NIBFuncionario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                new SqlParameter("@NIBFuncionario", NIBFuncionario),
            };
                return dal.executarReader("SELECT * FROM Funcionarios WHERE [NIBFuncionario]=@NIBFuncionario", sqlParams);
            }
            //Load da Tabela de Funcionários
            static public DataTable LoadFuncionarios()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT IdFuncionario, Username, NomeFuncionario, MoradaFuncionario, EmailFuncionario, ContactoFuncionario, NIBFuncionario, NIFFuncionario, Administrador, Ativo  FROM Funcionarios", null);
            }           
            //Inserir Funcionários na Tabela Funcionarios
            static public int InsertFuncionario(string Username, string Password, string NomeFuncionario, string MoradaFuncionario, string EmailFuncionario, string ContactoFuncionario, string NIBFuncionario, string NIFFuncionario, bool Administrador, bool Ativo, bool Login)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@Password", Password),
                    new SqlParameter("@NomeFuncionario", NomeFuncionario),
                    new SqlParameter("@MoradaFuncionario", MoradaFuncionario),
                    new SqlParameter("@EmailFuncionario", EmailFuncionario),
                    new SqlParameter("@ContactoFuncionario", ContactoFuncionario),
                    new SqlParameter("@NIBFuncionario", NIBFuncionario), 
                    new SqlParameter("@NIFFuncionario",NIFFuncionario),
                    new SqlParameter("@Administrador",Administrador),
                    new SqlParameter("@Ativo",Ativo),
                    new SqlParameter("@Login",Login),
                  
                    
                   

            };
                return dal.executarNonQuery("INSERT INTO Funcionarios (Username, Password, NomeFuncionario, MoradaFuncionario, EmailFuncionario, ContactoFuncionario, NIBFuncionario,  NIFFuncionario, Administrador, Ativo, Login) VALUES(@Username, @Password, @NomeFuncionario, @MoradaFuncionario, @EmailFuncionario, @ContactoFuncionario, @NIBFuncionario, @NIFFuncionario, @Administrador, @Ativo, @Login)", sqlParams);
            }
            
            //Fazer update dos dados dos Funcionários na Tabela Funcionarios com password
            static public int UpdateFuncionarioCP(string IdFuncionario, string Username, string Password, string NomeFuncionario, string MoradaFuncionario, string EmailFuncionario, string ContactoFuncionario, string NIBFuncionario, string NIFFuncionario, bool Administrador, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdFuncionario",IdFuncionario),
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@Password", Password),
                    new SqlParameter("@NomeFuncionario", NomeFuncionario),
                    new SqlParameter("@MoradaFuncionario", MoradaFuncionario),
                    new SqlParameter("@EmailFuncionario", EmailFuncionario),
                    new SqlParameter("@ContactoFuncionario", ContactoFuncionario),
                    new SqlParameter("@NIBFuncionario", NIBFuncionario),
                    new SqlParameter("@NIFFuncionario",NIFFuncionario),
                    new SqlParameter("@Administrador",Administrador),
                    new SqlParameter("@Ativo",Ativo),
                

            };
                return dal.executarNonQuery("UPDATE [Funcionarios] SET [Username]=@Username, [Password]=@Password, [NomeFuncionario]=@NomeFuncionario, [MoradaFuncionario]=@MoradaFuncionario, [EmailFuncionario]=@EmailFuncionario, [ContactoFuncionario]=@ContactoFuncionario, [NIBFuncionario]=@NIBFuncionario, [NIFFuncionario]=@NIFFuncionario, [Administrador]=@Administrador, [Ativo]=@Ativo WHERE [IdFuncionario]=@IdFuncionario", sqlParams);
            }

            //Fazer update dos dados dos Funcionários na Tabela Funcionarios sem password
            static public int UpdateFuncionarioSP(string IdFuncionario, string Username, string NomeFuncionario, string MoradaFuncionario, string EmailFuncionario, string ContactoFuncionario, string NIBFuncionario, string NIFFuncionario, bool Administrador, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdFuncionario",IdFuncionario),
                    new SqlParameter("@Username", Username),
                    new SqlParameter("@NomeFuncionario", NomeFuncionario),
                    new SqlParameter("@MoradaFuncionario", MoradaFuncionario),
                    new SqlParameter("@EmailFuncionario", EmailFuncionario),
                    new SqlParameter("@ContactoFuncionario", ContactoFuncionario),
                    new SqlParameter("@NIBFuncionario", NIBFuncionario),
                    new SqlParameter("@NIFFuncionario",NIFFuncionario),
                    new SqlParameter("@Administrador",Administrador),
                    new SqlParameter("@Ativo",Ativo),
                

            };
                return dal.executarNonQuery("UPDATE [Funcionarios] SET [Username]=@Username, [NomeFuncionario]=@NomeFuncionario, [MoradaFuncionario]=@MoradaFuncionario, [EmailFuncionario]=@EmailFuncionario, [ContactoFuncionario]=@ContactoFuncionario, [NIBFuncionario]=@NIBFuncionario, [NIFFuncionario]=@NIFFuncionario, [Administrador]=@Administrador, [Ativo]=@Ativo WHERE [IdFuncionario]=@IdFuncionario", sqlParams);
            }
            //Filtrar Funcionários
            internal static object FiltrarFuncionarios(string IdFuncionario, string Username, string NomeFuncionario, string MoradaFuncionario, string EmailFuncionario, string ContactoFuncionario, string NIBFuncionario, string NIFFuncionario)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@IdFuncionario", "%" + IdFuncionario + "%"),
                    new SqlParameter("@Username", "%" + Username + "%"),
                    new SqlParameter("@NomeFuncionario", "%" + NomeFuncionario + "%"),
                    new SqlParameter("@MoradaFuncionario", "%" + MoradaFuncionario + "%"),
                    new SqlParameter("@EmailFuncionario", "%" + EmailFuncionario + "%"),
                    new SqlParameter("@ContactoFuncionario", "%" + ContactoFuncionario + "%"),
                    new SqlParameter("@NIBFuncionario", "%" + NIBFuncionario + "%"),
                    new SqlParameter("@NIFFuncionario", "%" + NIFFuncionario + "%"),

                };

                return dal.executarReader("select IdFuncionario, Username, NomeFuncionario, MoradaFuncionario, EmailFuncionario, ContactoFuncionario, NIBFuncionario, NIFFuncionario, Administrador, Ativo from Funcionarios Where IdFuncionario like @IdFuncionario OR Username like @Username OR NomeFuncionario like @NomeFuncionario OR MoradaFuncionario like @MoradaFuncionario OR EmailFuncionario like @EmailFuncionario OR ContactoFuncionario like @ContactoFuncionario OR NIBFuncionario like @NIBFuncionario OR NIFFuncionario like @NIFFuncionario", sqlparams);
            }

        }

        public class produtos
        {
            //Load da Tabela Cartas
            static public DataTable LoadCartas()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT IdCarta, NomeCarta, Expansao, Tipo, Cor, Custo, Raridade, Preco, Quantidade, Imagem FROM Cartas", null);
            }
            //Load da Tabela OutrosProdutos
            static public DataTable LoadProdutos()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT IdProduto, NomeProduto, Preco, Quantidade, Imagem FROM OutrosProdutos", null);
            }
            //Load da Tabela Expansões
            static public DataTable LoadExpansoes()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT NomeExpansao FROM Expansoes", null);
            }
            //Load da Tabela Tipos
            static public DataTable LoadTipos()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT Tipo FROM TiposDeCartas", null);
            }
            //Load da Tabela Cores
            static public DataTable LoadCores()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT Cor FROM Cores", null);
            }
            //Load da Tabela Coleções
            static public DataTable LoadColecoes()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Colecoes", null);
            }
           
            //Load da Tabela Misc
            static public DataTable LoadMisc()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Misc", null);
            }
            //Filtrar Cartas
            internal static object FiltrarCartas(string NomeCarta)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@NomeCarta", NomeCarta + "%")};

                return dal.executarReader("select * from Cartas Where NomeCarta like @NomeCarta", sqlparams);
            }
            //Filtrar Cor 
            internal static object FiltrarCor(string Cor)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@Cor", Cor + "%")};

                return dal.executarReader("select * from Cartas Where Cor like @Cor", sqlparams);
            }
           
            //Filtrar Mana
            internal static object FiltrarMana(string Custo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@Custo", Custo)};

                return dal.executarReader("select * from Cartas Where Custo like @Custo", sqlparams);
            }

            
            
            
            //Adicionar Carta
            static public int InsertCarta(string NomeCarta, string Expansao, string Tipo, string Cor, string Custo, string Raridade, double Preco, int Quantidade, byte[] Imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@NomeCarta", NomeCarta),
                    new SqlParameter("@Expansao", Expansao),
                    new SqlParameter("@Tipo", Tipo),
                    new SqlParameter("@Cor", Cor),
                    new SqlParameter("@Custo", Custo),
                    new SqlParameter("@Raridade", Raridade),
                    new SqlParameter("@Preco", Preco),
                    new SqlParameter("@Quantidade", Quantidade),
                    new SqlParameter("@Imagem", Imagem),
                   
                  };
                return dal.executarNonQuery("INSERT INTO Cartas (NomeCarta, Expansao, Tipo, Cor, Custo, Raridade, Preco, Quantidade, Imagem) VALUES(@NomeCarta, @Expansao, @Tipo, @Cor, @Custo, @Raridade, @Preco, @Quantidade, @Imagem)", sqlParams);
            }
            //Atualizar Carta
            static public int UpdateCarta(int IdCarta, string NomeCarta, string Expansao, string Tipo, string Cor, string Custo, string Raridade, double Preco, int Quantidade, byte[] Imagem)          
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdCarta", IdCarta), 
                    new SqlParameter("@NomeCarta", NomeCarta),
                    new SqlParameter("@Expansao", Expansao),
                    new SqlParameter("@Tipo", Tipo),
                    new SqlParameter("@Cor", Cor),
                    new SqlParameter("@Custo", Custo),
                    new SqlParameter("@Raridade", Raridade),
                    new SqlParameter("@Preco", Preco),
                    new SqlParameter("@Quantidade", Quantidade),
                    new SqlParameter("@Imagem", Imagem),
                

            };
                return dal.executarNonQuery("UPDATE [Cartas] SET [NomeCarta]=@NomeCarta, [Expansao]=@Expansao, [Tipo]=@Tipo, [Cor]=@Cor, [Custo]=@Custo, [Raridade]=@Raridade, [Preco]=@Preco, [Quantidade]=@Quantidade, [Imagem]=@Imagem WHERE [IdCarta]=@IdCarta", sqlParams);
            }
            //Adicionar Coleção
            static public int InsertColecao(string NomeColecao)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@NomeColecao", NomeColecao),
                   
                  };
                return dal.executarNonQuery("INSERT INTO Colecoes (NomeColecao) VALUES(@NomeColecao)", sqlParams);
            }
            //Atualizar Coleção
            static public int UpdateColecao(int IdColecao, string NomeColecao)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdColecao", IdColecao),
                    new SqlParameter("@NomeColecao", NomeColecao),
            };
                return dal.executarNonQuery("UPDATE [Colecoes] SET [NomeColecao]=@NomeColecao WHERE [IdColecao]=@IdColecao", sqlParams);
            }
            //Adicionar Expansão
            static public int InsertExpansao(string expname)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@NomeExpansao", expname)
                };
                return dal.executarNonQuery("INSERT INTO Expansoes (NomeExpansao) VALUES(@NomeExpansao)", sqlParams);
            }
            //Atualizar Expansão
            static public int UpdateExpansao(int IdExpansao, string NomeExpansao, int IdColecao)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdExpansao", IdExpansao),
                    new SqlParameter("@NomeExpansao", NomeExpansao),
                    new SqlParameter("@IdColecao", IdColecao),
            };
                return dal.executarNonQuery("UPDATE [Expansoes] SET [NomeExpansao]=@NomeExpansao, [IdColecao]=@IdColecao WHERE [IdExpansao]=@IdExpansao", sqlParams);
            }
            //Adicionar Tipos
            static public int InsertTipo(string Tipo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Tipo", Tipo)
                };
                return dal.executarNonQuery("INSERT INTO TiposDeCartas (Tipo) VALUES(@Tipo)", sqlParams);
            }
            //Adicionar Cores
            static public int InsertCor(string Cor)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@Cor", Cor)
                };
                return dal.executarNonQuery("INSERT INTO Cores (Cor) VALUES(@Cor)", sqlParams);
            }
            //Adicionar Produto
            static public int InsertProduto(string NomeProduto, double Preco, int Quantidade, byte[] Imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@NomeProduto", NomeProduto),
                    new SqlParameter("@Preco", Preco),
                    new SqlParameter("@Quantidade", Quantidade),
                    new SqlParameter("@Imagem", Imagem),
                   
                  };
                return dal.executarNonQuery("INSERT INTO OutrosProdutos (NomeProduto, Preco, Quantidade, Imagem) VALUES(@NomeProduto, @Preco, @Quantidade, @Imagem)", sqlParams);
            }
            //Atualizar Produto
            static public int UpdateProduto(int IdProduto, string NomeProduto, double Preco, int Quantidade, byte[] Imagem)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdProduto", IdProduto),
                    new SqlParameter("@NomeProduto", NomeProduto),
                    new SqlParameter("@Preco", Preco),
                    new SqlParameter("@Quantidade", Quantidade),
                    new SqlParameter("@Imagem", Imagem),
                

            };
                return dal.executarNonQuery("UPDATE [OutrosProdutos] SET [NomeProduto]=@NomeProduto, [Preco]=@Preco, [Quantidade]=@Quantidade, [Imagem]=@Imagem WHERE [IdProduto]=@IdProduto", sqlParams);
            }
            //Atualizar Quantidade de Cartas 
            static public int UpdateQuantidadeCartas(int IdCarta, int Quantidade)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdCarta", IdCarta),
                    new SqlParameter("@Quantidade", Quantidade),
                    };
                return dal.executarNonQuery("UPDATE [Cartas] SET [Quantidade]=@Quantidade WHERE [IdCarta]=@IdCarta", sqlParams);
            }
        }

        public class clientes
        {
            //Load da Tabela Clientes
            static public DataTable LoadClientes()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Clientes", null);
            }
            //Inserir Clientes na Tabela Clientes
            static public int InsertCliente(string NomeCliente, string MoradaCliente, string EmailCliente, string ContactoCliente, string NIBCliente, string NIFCliente, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@NomeCliente", NomeCliente),
                    new SqlParameter("@MoradaCliente", MoradaCliente),
                    new SqlParameter("@EmailCliente", EmailCliente),
                    new SqlParameter("@ContactoCliente", ContactoCliente),
                    new SqlParameter("@NIBCliente", NIBCliente),
                    new SqlParameter("@NIFCliente", NIFCliente),
                    new SqlParameter("@Ativo",Ativo)

            };
                return dal.executarNonQuery("INSERT INTO Clientes (NomeCliente, MoradaCliente, EmailCliente, ContactoCliente, NIBCliente, NIFCliente, Ativo) VALUES(@NomeCliente, @MoradaCliente, @EmailCliente, @ContactoCliente, @NIBCliente, @NIFCliente, @Ativo)", sqlParams);
            }
            //Fazer update dos dados dos Clientes na Tabela
            static public int UpdateCliente(string IdCliente, string NomeCliente, string MoradaCliente, string EmailCliente, string ContactoCliente, string NIBCliente, string NIFCliente, bool Ativo)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[]{
                    new SqlParameter("@IdCliente",IdCliente),
                    new SqlParameter("@NomeCliente", NomeCliente),
                    new SqlParameter("@MoradaCliente", MoradaCliente),
                    new SqlParameter("@EmailCliente", EmailCliente),
                    new SqlParameter("@ContactoCliente", ContactoCliente),
                    new SqlParameter("@NIBCliente", NIBCliente),
                    new SqlParameter("@NIFCliente", NIFCliente),
                    new SqlParameter("@Ativo",Ativo)
            };
                return dal.executarNonQuery("UPDATE [Clientes] SET [NomeCliente]=@NomeCliente, [MoradaCliente]=@MoradaCliente, [EmailCliente]=@EmailCliente, [ContactoCliente]=@ContactoCliente, [NIBCliente]=@NIBCliente, [NIFCliente]=@NIFCliente, [Ativo]=@Ativo WHERE [IdCliente]=@IdCliente", sqlParams);
            }
            //Filtrar Clientes
            internal static object FiltrarClientes(string NomeCliente)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlparams = new SqlParameter[]{
                    new SqlParameter("@NomeCliente", NomeCliente + "%")};

                return dal.executarReader("select * from Cliente Where NomeCliente like @NomeCliente", sqlparams);
            }
        }
        
        public class vendas
        {
            //Load da Tabela de Vendas
            static public DataTable LoadVenda()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Venda", null);
            }
            //Vender 
            static public int Vender( int IdFuncionario, int IdCliente, int IdCarta, int IdProduto)
                {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdFuncionario", IdFuncionario),
                    new SqlParameter("@IdCliente", IdCliente),
                    new SqlParameter("@IdCarta", IdCarta),
                    new SqlParameter("@IdProduto", IdProduto)
 
                };
                return dal.executarNonQuery("INSERT INTO Venda (IdFuncionario, IdCliente, IdCarta, IdProduto) VALUES(@IdFuncionario, @IdCliente, @IdCarta, @IdProduto)", sqlParams);
            }
        }   

        public class encomendas
        {
            //Load da Tabela das Encomendas
            static public DataTable LoadEncomenda()
            {
                DAL dal = new DAL();
                return dal.executarReader("SELECT * FROM Encomenda", null);
            }
            //Encomendar 
            static public int Encomendar(int IdFuncionario, int IdCliente, int IdCarta, int IdProduto)
            {
                DAL dal = new DAL();
                SqlParameter[] sqlParams = new SqlParameter[] {
                    new SqlParameter("@IdFuncionario", IdFuncionario),
                    new SqlParameter("@IdCliente", IdCliente),
                    new SqlParameter("@IdCarta", IdCarta),
                    new SqlParameter("@IdProduto", IdProduto),
 
                };
                return dal.executarNonQuery("INSERT INTO Encomenda (IdFuncionario, IdCliente, IdCarta, IdProduto) VALUES(@IdFuncionario, @IdCliente, @IdCarta, @IdProduto)", sqlParams);
            }
        }
    }
}
