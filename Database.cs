using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data.SqlClient;
using System.Data;
public class Database : MonoBehaviour {


	private string con;
	private static SqlConnection conexao;

	public static int progresso, vidaA, inimigos,quantidade,id_item,id_stat,id_slot,contador;
	public static string tempo, nome_item, nome_slot;
	public static bool newGame,numslot;



	// Use this for initialization
	void Start () {

		con = "Server =127.0.0.1;" +
			"Database = osegredodafloresta;" +
			"User ID = sa;" +
			"Pooling = false;" + 
			"password =M@th1435";

	}

	// Update is called once per frame
	void Update () {
		ConectarBanco (con);

	}

	//Faz a conexão com o banco
	void ConectarBanco(string _source)
	{
		conexao = new SqlConnection (_source);
		conexao.Open ();
	}

	public void CarregarJogo()
	{
		
	}


	public void CarregarJogo1()
	{
		if (!newGame) {
			nome_slot = "Slot 1";
			CarregarSlot1 (conexao, nome_slot);
		}

	}

	public void CarregarJogo2()
	{
		if (!newGame) {
			nome_slot = "Slot 2";
			CarregarSlot1 (conexao,nome_slot);
		}
	}

	public void CarregarJogo3()
	{
		if (!newGame) {
			nome_slot = "Slot 3";
			CarregarSlot1 (conexao, nome_slot);
		}
	}
	//Carregar slot 1
	void CarregarSlot1(SqlConnection conex, string _nome_slot)
	{
		SqlCommand consultarslot1 = conex.CreateCommand ();
		consultarslot1.CommandText = "SELECT FK_ID_item,FK_ID_stat from Slots where nome_slot = '" + _nome_slot + "'";
		SqlDataReader leitorslot1 = consultarslot1.ExecuteReader ();
		while (leitorslot1.Read ()) {
			id_item = (int)leitorslot1 ["FK_ID_item"];
			id_stat = (int)leitorslot1 ["FK_ID_stat"];
		}
		leitorslot1.Close ();
		leitorslot1 = null;


		SqlCommand consultarestat1 = conex.CreateCommand ();
		consultarestat1.CommandText = "SELECT progresso,vida_atual,inimigos_derrotados FROM Estatisticas where Id_stat = '" + id_stat + "'";
		SqlDataReader leitorestat1 = consultarestat1.ExecuteReader ();
		while (leitorestat1.Read ()) {
			progresso = (int)leitorestat1 ["progresso"];
			vidaA = (int)leitorestat1 ["vida_atual"];
			inimigos = (int)leitorestat1 ["inimigos_derrotados"];
		}

		leitorestat1.Close ();
		leitorestat1 = null;


		SqlCommand consultaritem1 = conex.CreateCommand ();
		consultaritem1.CommandText = "SELECT nome_item,quantidade_item from ItensJogo where Id_item = '" + id_item +  "'";
		SqlDataReader leitoritem1 = consultaritem1.ExecuteReader ();
		while (leitoritem1.Read ()) {
			nome_item = (string)leitoritem1 ["nome_item"];
			quantidade = (int)leitoritem1 ["quantidade_item"];
		}
		leitoritem1.Close ();
		leitoritem1 = null;
	}

	void InserirSlot(SqlConnection conex,string _nome_slot)
	{
			SqlCommand consultaItens = conex.CreateCommand ();
			consultaItens.CommandText = "SELECT FK_ID_item, FK_ID_stat from Slots where nome_slot = '" + _nome_slot + "'";
			SqlDataReader lerconsulta = consultaItens.ExecuteReader ();
		while (lerconsulta.Read ()) {
			id_item = (int)lerconsulta ["FK_ID_item"];
			id_stat = (int)lerconsulta ["FK_ID_stat"];
		}
			lerconsulta.Close ();

			SqlCommand inserirslot = conex.CreateCommand ();
			inserirslot.CommandText = "update ItensJogo set quantidade_item = 0 where id_item = '" + id_item + "'";
			SqlDataReader lerslots = inserirslot.ExecuteReader ();
			lerslots.Read ();
			lerslots.Close ();

			SqlCommand inseriritem = conex.CreateCommand ();
			inseriritem.CommandText = "update Estatisticas set progresso = 1, vida_atual = 3, inimigos_derrotados = 0 where id_stat = '" + id_stat + "'";
			SqlDataReader leritens = inseriritem.ExecuteReader ();
			leritens.Read ();
			leritens.Close ();
	}

	void SalvarDados (SqlConnection conex,string _nome_slot)
	{
		quantidade = Player.coins;
		vidaA = Player.actLifeP;
		inimigos = Player.iniDerrotados;

		SqlCommand salvarItens = conex.CreateCommand ();
		salvarItens.CommandText = "SELECT FK_ID_item, FK_ID_stat from Slots where nome_slot = '" + _nome_slot + "'";
		SqlDataReader leitorsalvaritens = salvarItens.ExecuteReader ();
		while (leitorsalvaritens.Read ()) {
			id_item = (int)leitorsalvaritens ["FK_ID_item"];
			id_stat = (int)leitorsalvaritens ["FK_ID_stat"];
		}
		leitorsalvaritens.Close ();

		SqlCommand atualizaritens = conex.CreateCommand ();
		atualizaritens.CommandText = "update ItensJogo set quantidade_item = '" + quantidade + "' where id_item = '" + id_item + "'";
		SqlDataReader lerslots = atualizaritens.ExecuteReader ();
		lerslots.Read ();
		lerslots.Close ();

		SqlCommand inseriritem = conex.CreateCommand ();
		inseriritem.CommandText = "update Estatisticas set progresso = '" + progresso + "', vida_atual = '" + vidaA + "', inimigos_derrotados = '" + inimigos + "' where id_stat = '" + id_stat + "'";
		SqlDataReader leritens = inseriritem.ExecuteReader ();
		leritens.Read ();
		leritens.Close ();
	}

	public void NovoJogo()
	{
		newGame = true;
		ConsultarSlot (conexao);
	}

	public void NovoSlot1()
	{
		if (newGame) {
			nome_slot = "Slot 1";
			InserirSlot (conexao, nome_slot);
			CarregarSlot1 (conexao, nome_slot);
		}
	}

	public void NovoSlot2()
	{
		if (newGame) {
			nome_slot = "Slot 2";
			InserirSlot (conexao,nome_slot);
			CarregarSlot1 (conexao, nome_slot);
		}
	}

	public void NovoSlot3()
	{
		if (newGame) {
			nome_slot = "Slot 3";
			InserirSlot (conexao,nome_slot);
			CarregarSlot1 (conexao, nome_slot);
		}
	}




	public void SalvarJogo()
	{
		SalvarDados (conexao, nome_slot);	
	}


	void ConsultaIds(SqlConnection conx){
		SqlCommand comandoconsulta = conx.CreateCommand ();
		comandoconsulta.CommandText = "SELECT es.Id_stat,ij.Id_item from Estatisticas as es inner join Slots as sl on Id_stat = FK_ID_stat inner join ItensJogo as ij on Id_item = FK_ID_item";
		SqlDataReader lerconsulta = comandoconsulta.ExecuteReader ();
		while (lerconsulta.Read ()) {
			id_stat = (int)lerconsulta ["Id_stat"];
			id_item = (int)lerconsulta ["Id_item"];
		}

		lerconsulta.Close ();
	}

	public void Atualizar()
	{
		quantidade = Player.coins;
		vidaA = Player.actLife;
		ConsultaIds (conexao);
	}


	void ConsultarSlot(SqlConnection conex)
	{
		SqlCommand lerSlot = conex.CreateCommand ();
		lerSlot.CommandText = "SELECT nome_slot from Slots";
		SqlDataReader leitorslot = lerSlot.ExecuteReader ();
		while (leitorslot.Read ()) {
			nome_slot = (string)leitorslot ["nome_slot"];
		}
		leitorslot.Close ();
		leitorslot = null;

		if (nome_slot == null) {
			for (contador = 1; contador <= 3; contador++) {
				SqlCommand inserirstat = conex.CreateCommand ();
				inserirstat.CommandText = "INSERT INTO Estatisticas (progresso,vida_atual,inimigos_derrotados) values(0,0,0)";
				SqlDataReader leitorstat = inserirstat.ExecuteReader ();
				leitorstat.Read ();
				leitorstat.Close ();
				leitorstat = null;

				SqlCommand consultastat = conex.CreateCommand ();
				consultastat.CommandText = "SELECT Id_stat from Estatisticas";
				SqlDataReader leitorestat = consultastat.ExecuteReader ();
				while (leitorestat.Read ()) {
					id_stat = (int)leitorestat ["Id_stat"];
				}
				leitorestat.Close ();
				leitorestat = null;


				SqlCommand inserirItem = conex.CreateCommand ();
				inserirItem.CommandText = "INSERT INTO ItensJogo(nome_item,quantidade_item) values('Moeda',0)";
				SqlDataReader leitorItem = inserirItem.ExecuteReader ();
				leitorItem.Read ();
				leitorItem.Close ();
				leitorItem = null;


				SqlCommand consultaItem = conex.CreateCommand ();
				consultaItem.CommandText = "SELECT Id_item FROM ItensJogo";
				SqlDataReader leritem = consultaItem.ExecuteReader ();
				while (leritem.Read ()) {
					id_item = (int)leritem ["Id_item"];
				}
				leritem.Close ();
				leritem = null;


				SqlCommand inserirSlot = conex.CreateCommand ();
				inserirSlot.CommandText = "INSERT INTO Slots(nome_slot,FK_ID_item,FK_ID_stat) values('Slot " + contador + "','" + id_item + "','" + id_stat + "')";
				SqlDataReader leitorSlot = inserirSlot.ExecuteReader ();
				leitorSlot.Read ();
				leitorSlot.Close ();
				leitorSlot = null;
			}
		} else {
		}
	}
}

