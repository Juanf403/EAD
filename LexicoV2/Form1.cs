using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LexicoV2
{
    public partial class Form1 : Form
    {
        #region MIERDA2
        int banderapostpre = 2;
         List<CUADRUPLOS> listatripleta = new List<CUADRUPLOS>();
        List<depurarnormal> listadepurados = new List<depurarnormal>();
        List<letreros> listaletreros = new List<letreros>();

        variablesassembler var = new variablesassembler();
        List<variablesassembler> misvariables = new List<variablesassembler>();
       
        //la direccion de la base de datos
        String Stringconnection = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Users\juanm\Documents\ITNL\9no\LYA2\lya\automatas.mdb;Persist Security Info=True";
        //"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\GSK\\Desktop\\AUTOMATAS.accdb;Persist Security Info=True";
        int click = 0, click2 = 0, click3 = 0, IDcontador = 0, ContCade = 0;
        List<Tripleta> misTripleatas = new List<Tripleta>();
        List<Cuadruplo> misCuadruplos = new List<Cuadruplo>();
        List<string> listaIDs = new List<string>();
        List<string> listaCNENs = new List<string>();        
        List<string> listaCADEs = new List<string>();
        List<string> modificados = new List<string>();
        string cadena = "", estado = "1", pila = "",primeroopl="",TIPO="",SOLOUNTOKEN="";
        ArrayList StartTRUE = new ArrayList();
        ArrayList StartFalse = new ArrayList();
        ArrayList RenglonesNuevos = new ArrayList();
        int op = 0,ENTRO=0;
        int ContLetras = 0, ContLineas = 0, ContErrores = 0, contNum = 0, N = 0, pos = 0, Ntokens = 0, pos2 = 0,PRIMERO=0,CONTADORDEIF=1,contadordedireccionamientoafin=0,agregadoalfindesinciclo=0;
        int incremento = 0, PASOPORCICLO = 1, pa = 0, inicioejecuta = 0, banderainicioyfin = 1, FINTRUE = 0;
        string LI = "", LD = "", Tokens = "";
        string tipo = "",tipodeinstruccion="";
        int te = 1;
        string cadaux2 = "";
        string contTE = "";
        string primero = "", segundo = "";
        int esta = 0;
        string cadenaaux2 = "";
        int pasada = 1, indice = 1, TR = 1, pasadaOPL = 1;
        int indicecadenaauxiliar = 0;
        string cadenaauxiliar = "";
        string cadenaoriginal = "";
        bool esopl = false;
        string CICLO = "";
        int doblecomparacion = 0;
        int checarotroopl = 0;
        string semanticaend = "";
        int otroopl = 0;
        int paso = 0, cantidaddeoperadoresAND = 0, cantidaddeoperadoresOR=0;
        int indicelineaporlineaauxiliar = 0;
        //string cadena3 = "";
        ArrayList FINTRUEIF = new ArrayList();
        ArrayList FINFALSEIF = new ArrayList();
        ArrayList finprimerif = new ArrayList();
        ArrayList findecadainstruccion = new ArrayList();
        ArrayList CadenaOriginal = new ArrayList();
        ArrayList CadenaAuxiliar = new ArrayList();
        ArrayList StartFOR = new ArrayList();
        ArrayList StartWhile = new ArrayList();
        ArrayList StartDOWHILE = new ArrayList();
        ArrayList CadenaAuxiliar2 = new ArrayList();
        ArrayList DatObjeto = new ArrayList();
        ArrayList DatFuente = new ArrayList();
        ArrayList Oper = new ArrayList();
        ArrayList LinePorLineaOriginal = new ArrayList();
        ArrayList LinePorLineaAuxiliar = new ArrayList();
        ArrayList TE = new ArrayList();
        ArrayList ContenidoTE = new ArrayList();
     

        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnCargar_Click(object sender, EventArgs e)
        {
        }
        private void txtSiguiente_Click(object sender, EventArgs e)
        {
            
            string palabra = "", token = "";
            
            ContLetras = 0;
            incremento = 100 / richTextBox1.Lines.Count();
            richTextBox1.ReadOnly = true;
            lblTotalLineas.Text = "Total de lineas: " + richTextBox1.Lines.Count();
            int codAcsii = 0;//inicializo mis variables en 0
            byte[] array;
            while (ContLineas < richTextBox1.Lines.Count())
            {
                token = "";
                ContLetras = 0;
                cadena = richTextBox1.Lines[ContLineas] + "\n";
                barra.Increment(incremento);

                ContLineas++;
                btnSiguiente.Enabled = true;
                lblLinea.Text = "Linea: " + ContLineas;

                while (ContLetras < cadena.Length)
                {
                    palabra = palabra + cadena[ContLetras].ToString();
                    array = Encoding.ASCII.GetBytes(cadena[ContLetras].ToString());//Se obtiene el codigo ACSII
                    codAcsii = int.Parse(array[0].ToString());
                    //Busca el estado en el datagrid ya previamente llenado 
                    estado = ConsultarEstado(codAcsii.ToString(), estado, dataGridView1);
                    if (estado == "ERROR")
                    {
                        richTextBox2.Text = richTextBox2.Text + estado + "\n";
                        token = estado;

                        estado = "1";
                        ContLetras = cadena.Length;
                        ContErrores++;

                        lblErrores.Text = "Errores: " + ContErrores;
                    }
                    else
                    {
                        string aux = ConsultarEstado("CAT", estado, dataGridView1);
                        if (aux != "")
                        {
                            token = aux;
                            // richTextBox2.Text = richTextBox2.Text + token + cadena[ContLetras];
                            DeterminarToken(token, palabra, cadena[ContLetras]);

                            aux = "";

                            estado = "1";
                            palabra = "";
                            //i++;
                        }
                    }
                    ContLetras++;
                }
            }
            MessageBox.Show("Termino de convertir a el codigo a tokens");
            richTextBox1.ReadOnly = false;
            btnSintactico.Enabled = true;
            btnNotaciones.Enabled = true;
            btntriplos.Enabled = true;

        }
        private string ConsultarEstado(string columna, string estado, DataGridView x)
        {
            int rowIndex = -1;
            DataGridViewRow row = x.Rows
                  .Cast<DataGridViewRow>()
                  .Where(r => r.Cells["ESTADO"].Value.ToString().Equals(estado))
                  .First();

            rowIndex = row.Index;//obtiene el index en donde se encuentra el estado en la tabla
            estado = x.Rows[rowIndex].Cells[columna].Value.ToString();//saca el estado siguiente
            return estado;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //richTextBox1.Text = "DESDE X $ 3 TERMINA X > 8 INTERVALO 1\nA $ 3\nFINDESDE";
            richTextBox1.Text = "CAPTURA X";
            
            try
            {
                //Formato para codigo;
                openFileDialog1.DefaultExt = "*.code";
                openFileDialog1.Filter = "CODE Files|*.code";
                saveFileDialog.DefaultExt = "*.code";
                saveFileDialog.Filter = "CODE Files|*.code";


                //formato para tokens
                openFileDialog2.DefaultExt = "*.token";
                openFileDialog2.Filter = "TOKEN Files|*.token";
                saveFileDialog1.DefaultExt = "*.token";
                saveFileDialog1.Filter = "TOKEN Files|*.token";
                Conexion.conexionString = Stringconnection;
                Conexion.nombreTabla = "Lexico2";
                Conexion.query = "select * from [{0}]";
               
                //richTextBox1.Text = "INICIO\nUBICAR ( 4 , 5 )\n\"HOLA MUNDO\"\n/*COMENTARIO GHG */\nFIN";
                //traego los datos a la datagrid
                dataGridView1.DataSource = Conexion.TraerTodosDatosDeBD();
                //Conexion.nombreTabla = "TODAS";
                //Conexion.query = "SELECT * FROM  [{0}]";
                //dataGridView2.DataSource = Conexion.TraerTodosDatosDeBD();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void abrirCodigo_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog1.FileName.Length > 0)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string fileText = File.ReadAllText(strfilename);
                    richTextBox1.Text = fileText;
                }
            }
        }
        private void btnSemantico_Click(object sender, EventArgs e)
        {
             richTextBox3.Clear();
            barra.Value = 0;
            incremento = 100 / 3;
            Conexion.nombreTabla = "REGLASEMANTICA";
            Conexion.query = "SELECT * FROM  [{0}]";
            dataGridView2.DataSource = Conexion.TraerTodosDatosDeBD();

            DefinirTipoDatoID(richTextBox2.Text);
            barra.Increment(incremento);
            //Pasada 2
            for (int i = 0; i < richTextBox2.Lines.Count() - 1; i++)
            {
                barra.Increment(incremento / richTextBox1.Lines.Count());
                richTextBox3.Text = richTextBox3.Text + "\n\n==============LINEA #" + (i + 1) + "==================\n\n";
                string cadena2 = richTextBox2.Lines[i].Replace(" ", String.Empty);
                cadena2 = CambiarTokens(cadena2, false);
                richTextBox3.Text = richTextBox3.Text + cadena2 + "\n";
                BottomUP(cadena2);
                // MessageBox.Show(cadena3, "Termino con la linea " + (i + 1) + "...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // cadena3 = "";
            }
            string aux = richTextBox2.Text.Replace(" ", string.Empty);
            aux = aux.Replace("\n", string.Empty);
            //Pasada 3

            MessageBox.Show(VerificarLogica(aux));
            MessageBox.Show("Termino analisis semantico");

           barra.Increment(incremento + 20);
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            semanticaend = "";
            lblTotalLineas.Text = "Total de Lineas:";
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear(); //---checar

            DGCadena.Rows.Clear();
            DGConstantesNum.Rows.Clear();
            DGIdentificadores.Rows.Clear();
            DGTokens.Rows.Clear();

            click = 0;
            click2 = 0;
            IDcontador = 0;
            ContCade = 0;
            listaIDs.Clear();
            cadena = "";
            estado = "1";
            //columna = "";
            ContLetras = 0;
            ContLineas = 0;
            ContErrores = 0;
            contNum = 0;
            lblErrores.Text = "";
            btnSintactico.Enabled = false;
            richTextBox1.ReadOnly = false;
            btntriplos.Enabled = false;
            btnSemantico.Enabled = false;
            btnNotaciones.Enabled = false;
            btnSintactico.Enabled = false;
            dataGridView3.Rows.Clear();
        }
        private void button1_Click(object sender, EventArgs e)
        {



        }

        public string tabla (string iden)
        {
            try
            {
                foreach (DataGridViewRow ROW in DGIdentificadores.Rows)
                {
                    if (ROW.Cells["Numero"].Value.ToString() == iden)
                    {
                        return ROW.Cells["DATOS"].Value.ToString();
                    }
                }
                return "ERROR";

            }
            catch (Exception x)
            {

                return "ERROR";
            }
        }
        public bool VALIDARDATOS(string linea)
        {
            string token = "";
            linea = linea.Replace("CAE(", "");
            linea = linea.Replace("CAE)", "");
            linea = linea.Replace("PR16", "");
            linea = linea.Replace("PR10", "");
            linea = linea.Replace(" ", String.Empty);
            if (linea.Length < 3)
            {
                return true;
            }
            try
            {
                for (int i = 0; i < linea.Length; i +=4)
                {
                    token = linea.Substring(i, 4);
                    //si el token es un identificador
                    if (token.Substring(0,2) == "ID")
                    {
                        string variable = token;
                        i += 4;
                        if (i >= linea.Length)
                        {
                            return true;
                        }
                        //si el identificador sigue una asignacion
                        if (linea.Substring(i, 4) == "CAE$")
                        {
                            i += 4;
                            //si aun hay tokens que leer
                            if (i >= linea.Length)
                            {
                                return false;
                            }
                            else
                            {
                                 //leer tipo de dato, CE CR CADENA
                                string tipo = linea.Substring(i,4);
                                switch (tipo.Substring(0,2))
                                {
                                    case "ID":
                                        foreach (DataGridViewRow item in DGIdentificadores.Rows)
                                        {
                                            if (item.Cells["Numero"].Value.ToString() == variable)
                                            {
                                                if (item.Cells["DATOS"].Value == null)
                                                {
                                                    item.Cells["DATOS"].Value = tabla(tipo);
                                                    break;
                                                }
                                                else
                                                {
                                                    if (item.Cells[2].Value.ToString() == tabla(tipo))
                                                    {
                                                        return true;
                                                    }
                                                    return false;
                                                }
                                            }
                                        }
                                        break;
                                    case "CR":
                                        foreach (DataGridViewRow  item in DGIdentificadores.Rows)
                                        {
                                            if (item.Cells["Numero"].Value.ToString() == variable)
                                            {
                                                if (item.Cells["DATOS"].Value == null)
                                                {
                                                    item.Cells["DATOS"].Value = "REAL";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (item.Cells[2].Value.ToString() == "REAL")
                                                    {
                                                        return true;
                                                    }
                                                    return false;
                                                }
                                            }
                                        }
                                        break;
                                    case "CE":
                                        foreach (DataGridViewRow item in DGIdentificadores.Rows)
                                        {
                                         
                                            if (item.Cells["Numero"].Value.ToString() == variable)
                                            {
                                               
                                                if (item.Cells[2].Value == null)
                                                {
                                                    item.Cells["DATOS"].Value = "ENTERO";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (item.Cells[2].Value.ToString() == "ENTERO")
                                                    {
                                                        return true;
                                                    }
                                                    return false;
                                                }
                                            }
                                        }
                                        break;
                                    case "CD":
                                        foreach (DataGridViewRow item in DGIdentificadores.Rows)
                                        {
                                            if (item.Cells["Numero"].Value.ToString() == variable)
                                            {
                                                if (item.Cells["DATOS"].Value == null)
                                                {
                                                    item.Cells["DATOS"].Value = "CADENA";
                                                    break;
                                                }
                                                else
                                                {
                                                    if (item.Cells[2].Value.ToString() == "CADENA")
                                                    {
                                                        return true;
                                                    }
                                                    return false;
                                                }
                                                
                                            }
                                        }
                                        break;
                                    default:
                                        return false;
                                    
                                }
                            }
                            
                        }
                    }
                }
                return true;
            }
            catch (Exception X)
            {
                MessageBox.Show("ERROR DE SINTAXIS EN:" + linea);
                return false;
            }
        }
        public bool SEGUNDA(string linea)
        {
            try
            {

                string token = "";
                linea = linea.Replace("CAE(", "");
                linea = linea.Replace("CAE)", "");
                linea = linea.Replace("PR16", "");
                linea = linea.Replace("PR10", "");
                linea = linea.Replace(" ", String.Empty);
                if (linea.Length < 3)
                {
                    return true;
                }
                string tipo = "";
                for (int i = 0; i < linea.Length; i += 4)
                {
                    string tipodato = linea.Substring(i, 4);
                    switch(tipodato.Substring(0,2))
                    {
                        case "ID":
                            if (tipo == string.Empty)
                            {
                                tipo = tabla(tipodato);
                                if (tipo == "ERROR")
                                {
                                  return false;
                                }
                            }
                            else
                            {
                                string tipodato2 = tabla(tipodato);
                                if (tipo == tipodato2)
                                {
                                    break;
                                }
                                else
                                {
                                    return false;
                                }
                               
                            }
                            break;
                        case "CE":
                            if (tipo == string.Empty)
                            {
                                tipo = "ENTERO";
                                
                            }
                            else
                            {
                                if (tipo == "ENTERO")
                                {
                                    break;
                                }
                                else
                                {
                                    return false;
                                }

                            }
                            break;
                        case "CR":
                            if (tipo == string.Empty)
                            {
                                tipo = "REAL";

                            }
                            else
                            {
                                if (tipo == "REAL")
                                {
                                    break;
                                }
                                else
                                {
                                    return false;
                                }

                            }
                            break;
                        case "CD":
                            if (tipo == string.Empty)
                            {
                                tipo = "CADENA";
                            }
                            else
                            {
                                if (tipo == "CADENA")
                                {
                                    break;
                                }
                                else
                                {
                                    return false;
                                }

                            }
                            break;
                    }
                   
                }
                return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }
        private void btnSintactico_Click(object sender, EventArgs e)
        {
            //primera pasada verificar tipo de dato y que ninguno identificador cambie su estado
            for (int i = 0; i < richTextBox2.Lines.Count() -1; i++)
            {
                if (!VALIDARDATOS(richTextBox2.Lines[i]))
                {
                    MessageBox.Show("error de sintaxis en la linea" + i.ToString() +" "+ richTextBox2.Lines[i] + " no se puede declarar una variable con tipos de datos diferentes.");
                    return;
                }
            }

            //segunda pasada validar que en la linea existan IDEN y CN del mismo tipo int double string.
            for (int i = 0; i < richTextBox2.Lines.Count() - 1; i++)
            {
                if (!SEGUNDA(richTextBox2.Lines[i]))
                {
                    MessageBox.Show("error de sintaxis en la linea" + i.ToString() + " " + richTextBox2.Lines[i] + " no se puede procesar diferentes tipos de datos");
                    return;
                }
            }
            //recorrer los tokens primero 

            barra.Value = 0;
            Conexion.nombreTabla = "TODAS";
            Conexion.query = "SELECT * FROM  [{0}]";
            dataGridView2.DataSource = Conexion.TraerTodosDatosDeBD();
            int x = richTextBox1.Lines.Count();

            for (int i = 0; i < x; i++)
            {
                barra.Increment(incremento);
                richTextBox3.Text = richTextBox3.Text + "\n\n==============LINEA #" + (i + 1) + "==================\n\n";
                string cadena2 = richTextBox2.Lines[i].Replace(" ", String.Empty);
                cadena2 = CambiarTokens(cadena2, true);
                richTextBox3.Text = richTextBox3.Text + cadena2 + "\n";
                BottomUP(cadena2);
                //MessageBox.Show(cadena3, "Termino con la linea " + (i + 1) + "...", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //cadena3 = "";
            }
            richTextBox3.Text = richTextBox3.Text + "\n ANALIZADOR DE TOKENS DE LAS LINEAS \n";
            richTextBox3.Text = richTextBox3.Text + "\n"+ semanticaend + "\n";
            if (BottomUP(semanticaend) != "ACEPTA")
            {
                richTextBox3.Text += " \n ERROR";
            }
            
            MessageBox.Show("Termino analisis sintactico");
            //DialogResult result = new DialogResult();


            btnSemantico.Enabled = true;
            //fin del semantico correctamente, inicializar las tripletas.
         //   prefijo(richTextBox2.Text.Replace("\n",""));

        }
        private void tablaDeGramaticaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (click3 == 0)
            {

                panel3.Height = this.Height;
                panel3.Width = this.Width;
                panel3.Visible = true;
                click3++;

            }
            else
            {
                panel3.Visible = false;

                click3 = 0;
            }
        }
        public int getpos(string cadena,int i)
        {
            try
            {
                int suma = 0;
                string token = "";
                int ret = 0;
                for (int j = 0; j < cadena.Length; j+=4)
                {
                    token = cadena.Substring(j, 4);
                    if (token == "CAE(")
                    {
                        suma++;
                    }
                    else
                    {
                        if (token == "CAE)")
                        {
                            suma--;
                            if (suma == 0)
                            {
                                ret = j;
                                break;
                            }
                        }
                    }
                }
                return ret;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int Jerarquia(string token)
        {
            try
            {
               
                if (token == "OPA=")
                {
                    return 1;
                }
                if (token == "OPA+" || token == "OPA-")
                {
                    return 2;
                }
                if (token == "OPA*" || token == "OPA/")
                {
                    return 3;
                }
                return 4;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string prefijo(string cadenarecursivo)
        {
           cadenarecursivo =  cadenarecursivo.Replace(" ", "");
           cadenarecursivo = cadenarecursivo.Replace("CAE$", "OPA=");
            try
            {
                List<string> P = new List<string>();
                
                string s = "";
                int pos = 0;
                for (int i = 0; i < cadenarecursivo.Length; i+=4)
                {
                    string tokenactual = cadenarecursivo.Substring(i, 4);
                    if (tokenactual == "PR04")
                    {
                        s += tokenactual;
                        i += 4;
                        string cadena = "";
                        tokenactual = cadenarecursivo.Substring(i, 4);
                        while (tokenactual != "PR25")
                        {
                            cadena += tokenactual;
                            i += 4;
                            tokenactual = cadenarecursivo.Substring(i, 4);
                        }
                        s += prefijo(cadena);
                    }
                    if (tokenactual.Substring(0,3) == "OPA")
                    {
                        if (P.Count == 0)
                        {
                            P.Add(tokenactual);
                        }
                        else
                        {
                            if (Jerarquia(tokenactual) > Jerarquia(P[P.Count -1]))
                            {
                                P.Add(tokenactual);
                            }
                            else
                            {
                                for (int j = P.Count; j > 0; j--)
                                {
                                    s += P[j -1];
                                    P.Remove(P[j - 1]);
                                    if (Jerarquia(tokenactual) > Jerarquia(P[j-2]))
                                    {
                                        P.Add(tokenactual);
                                        break;
                                    }
                                    else
                                    {
                                        string auxiliar = P[j-1];
                                        P.Remove(P[j - 1]);
                                        P.Add(tokenactual);
                                        P.Add(auxiliar);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (tokenactual == "CAE(")
                        {
                            pos = getpos(cadenarecursivo.Substring(i), i);
                            s += prefijo(cadenarecursivo.Substring(i+4, pos -4));
                            i += pos; //←←←←←← DUDAAAAA
                        }
                        else
                        {
                            s += tokenactual;
                        }
                    }
                }
                for (int i = P.Count; i > 0; i--)
                {
                    s += P[i -1];
                }

                return s;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private string BottomUP(string cadena)
        {
            //cadena tokens
            Ntokens = cadena.Length / 4;
            N = Ntokens;
            if (cadena == "S" || cadena == "S ")
            {
                MessageBox.Show("EL ANALIZADOR SEMANTICO TERMINO EXITOSAMENTE.");
                return "ACEPTA";
            }
            else
            {
                while (N >= 1)
                {
                    for (int i = 0; i <= Ntokens * 4 && (i / 4) + N <= Ntokens; i += 4)
                    {
                        if (ConsultarGramatica(cadena.Substring(i, N * 4), dataGridView2) != "")
                        {
                            cadena = cadena.Remove(i, N * 4);
                            cadena = cadena.Insert(i, LI);
                            richTextBox3.Text = richTextBox3.Text + cadena + "\n";
                            return BottomUP(cadena);
                        }
                    }
                    N--;
                }
                if (cadena == "COND")
                {
                    semanticaend += "COND";
                }
                if (cadena == "INIC" || cadena == "FINA")
                {
                    semanticaend += cadena;
                }
                richTextBox3.Text = richTextBox3.Text + Error.DeterminarError(cadena) + "\n";
                ContErrores++;
                lblErrores.Text = "ERRORES: " + ContErrores.ToString();
                if (cadena != "INIC" && cadena != "FINA" && cadena != "COND")
                {
                    MessageBox.Show("ERROR EN LA SINTAXIS: " + cadena);
                    semanticaend += cadena;
                }     
                return "Error";
            }
        }
      
        private string ConsultarGramatica(string cade, DataGridView x)
        {
            try
            {
                int rowIndex = -1;
                LD = "";
                DataGridViewRow row = x.Rows
                      .Cast<DataGridViewRow>()
                      .Where(r => r.Cells["LD"].Value.ToString().Equals(cade))
                      .First();

                rowIndex = row.Index;//obtiene el index en donde se encuentra el estado en la tabla
                LD = x.Rows[rowIndex].Cells["LD"].Value.ToString();
                LI = x.Rows[rowIndex].Cells["LI"].Value.ToString();
                return LD;
            }
            catch (Exception)
            {
                return LD;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string cadena2 = "";

            //for (int i = 0; i < richTextBox2.Lines.Count() - 1; i++)
            //{
            //    cadena2 = richTextBox2.Lines[i].Replace(" ", String.Empty);
            //    if (cadena2.Substring(0, 4).Contains("PR04"))
            //    {
            //        CICLO = "DESDE";
            //        PASOPORCICLO = 2;
            //    }
            //    else if (cadena2.Substring(0, 4).Contains("PR05"))
            //    {
            //        CICLO = "EJECUTA";
            //        PASOPORCICLO = 2;
            //    }
            //    else if (cadena2.Substring(0, 4).Contains("PR13"))
            //    {
            //        CICLO = "HACER";
            //        PASOPORCICLO = 2;
            //    }
            //    string cadenaAUX = Limitantes(cadena2);
            //    PASOPORCICLO = 1;
            //    if (cadenaAUX != null)
            //    {
            //        //MessageBox.Show(cadenaAUX);

            //        //x $ y + 5 ^ 3
            //    }
            //}

            //DialogResult dr = MessageBox.Show("Que tipo de notacion desea utilizar?\n yes = Prefija \nNo=Postifja", "Discard Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            //if (dr == DialogResult.Yes)
            //{

            //    MessageBox.Show(invertirCadena(NotacionPrefija(invertirCadena(cadena2))));
            //}
            //else
            //{
            //    for (int i = 0; i < LinePorLineaOriginal.Count; i++)
            //    {
            //        MessageBox.Show(NotacionPostfija(Convert.ToString(LinePorLineaOriginal[i])));
            //        textBox1.Text = Convert.ToString(LinePorLineaAuxiliar[i]);
            //    }
            //    MessageBox.Show("Termino las notaciones postfija");
            //}
        }

        private void abrirTokens_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK && openFileDialog2.FileName.Length > 0)
            {
                if ((myStream = openFileDialog2.OpenFile()) != null)
                {
                    string strfilename = openFileDialog2.FileName;
                    string fileText = File.ReadAllText(strfilename);
                    richTextBox2.Text = fileText;
                }
            }
        }
        private string CambiarTokens(string cadena, bool SintcORSemant)
        {
            while (cadena.Contains("CD") || cadena.Contains("CE") || cadena.Contains("CR"))
            {
                if (cadena.Contains("CE"))
                {
                    cadena = cadena.Replace(cadena.Substring(cadena.IndexOf("CE"), 4), "CNEN");
                }
                else if (cadena.Contains("CR"))
                {
                    cadena = cadena.Replace(cadena.Substring(cadena.IndexOf("CR"), 4), "CNRE");
                }
                else if (cadena.Contains("CD"))
                {
                    cadena = cadena.Replace(cadena.Substring(cadena.IndexOf("CD"), 4), "CADE");
                }
            }

            for (int j = 0; j < DGIdentificadores.Rows.Count; j++)
            {
                string aux = DGIdentificadores.Rows[j].Cells[0].Value.ToString();
                if (cadena.Contains(aux))
                {
                    if (SintcORSemant)
                    {
                        cadena = cadena.Replace(aux, "IDEN");
                    }
                    else
                    {
                        try
                        {
                            cadena = cadena.Replace(aux, DGIdentificadores.Rows[j].Cells[2].Value.ToString());
                        }
                        catch
                        {
                            ContErrores++;
                            lblErrores.Text = "ERRORES: " + ContErrores.ToString();
                            return "No se declaro el identificador " + aux;
                        }
                    }

                }
            }

            return cadena;
        }


        private string VerificarLogica(string cadena)
        {
            int contadorLogica = 0;
            for (int i = 0; i < cadena.Length; i += 4)
            {
                string aux = cadena.Substring(i, 4);

                if (aux == "PR16" || aux == "PR21" || aux == "PR01" || aux == "PR13" || aux == "PR05" || aux == "PR04")
                {
                    contadorLogica++;
                }

                else if (aux == "PR10" || aux == "PR12" || aux == "PR08" || aux == "PR09" || aux == "PR11" || aux == "PR14")
                {
                    contadorLogica--;
                }
            }
            if (contadorLogica == 0)
            {
                return "Logica Correcta";
            }
            else
            {
                //No recuerdo cuando es abierto y cerrado
                if (contadorLogica == -1)
                {
                    return "Error Logica: Falto la palabra reservada de abertura";
                }
                else
                {
                    return "Error Logica: Falto la palabra reservada de cierre";
                }
               
            }

        }
        private void tablaDeTokensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (click2 == 0)
            {
                //button2.Visible = false;
                btnSintactico.Visible = false;
                btnLimpiar.Visible = false;
                btnSemantico.Visible = false;
                btnSiguiente.Visible = false;
                panel2.Height = this.Height;
                panel2.Width = this.Width;
                panel2.Visible = true;
                click2++;
                //tripletas.Visible = false;
            }
            else
            {
                panel2.Visible = false;
                btnSintactico.Visible = true;
                btnLimpiar.Visible = true;
                btnSemantico.Visible = true;
                btnSiguiente.Visible = true;
                click2 = 0;
            }
        }
        #endregion
        #region mistripletas
        private void button2_Click_1(object sender, EventArgs e)
        {
            List<string> todo = new List<string>();

            string S = "";
            for (int i = 0; i < richTextBox2.Lines.Count(); i++)
            {
                todo.Add(prefijo(richTextBox2.Lines[i].ToString()));
            }
            foreach (string item in todo)
            {
                if (item.Length > 0)
                {
                    S += item + "||||";
                }
            }
            TRIPLETA(S);
            
                CUADRUPLOS variable = new CUADRUPLOS();
                variable.memoria =  listatripleta.Count;
                variable.accion = "FINAL";
                variable.temporal = "TE00";
                variable.valor = "FINAL";
                listatripleta.Add(variable);
            tripletas.DataSource = null;
            tripletas.DataSource = listatripleta;
            //TOMAR listatripleta y pasarlo a ensamblador FINALLL BITCHES!!! MADAFAQA
            TURBOASSEMBLER();

        }
        static void Addtext(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }
        public void limpiarvarensamblador()
        {
            foreach (var item in misvariables)
            {
                item.valor = "";
            }
            return;
        }
      
        public string validartemporal(string temporal)
        {
            try
            {
                foreach (var item in misvariables) //busco si el temporal esta en bl al ah bh
                {
                    if (item.valor == temporal)
                    {
                        return item.variable;
                    }
                }
                //BUSCAR EL TEMPORAL EN VARIABLES.
                foreach (var item in listadepurados)
                {
                    if (!string.IsNullOrEmpty(item.Temporal)) 
                    {
                        if (item.Temporal == temporal)
                        {                
                            return valortemporaldepurados(temporal);
                        }
                   
                    }
                }
                //termine de recorer mis variables y no lo encontre, debo de buscar una variable disponible y asignarla
                foreach (var item in misvariables)
                {
                    if (string.IsNullOrEmpty(item.valor))  //encontre un temporal disponible
                    {
                        item.valor = temporal;
                        return item.variable;
                    }
                }
                return temporal;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public string valorconstantenumerica(string constante)
        {
            for (int i = 0; i < DGConstantesNum.Rows.Count; i++)
            {
                if (DGConstantesNum.Rows[i].Cells[0].Value.ToString() == constante)
                {
                    return DGConstantesNum.Rows[i].Cells[1].Value.ToString();
                }
            }
            return"";
        }
        public string valortemporaldepurados(string temporal) //de temporal01 obtener ID01.... DE ID01 OBTENER A
        {
            foreach (var item in listadepurados)
            {
                if (item.Temporal == temporal)
                {
                    //obtengo ID01
                    for (int i = 0; i < DGIdentificadores.Rows.Count; i++)
                    {
                        if (DGIdentificadores.Rows[i].Cells[0].Value.ToString() == item.ID)
                        {
                            return DGIdentificadores.Rows[i].Cells[1].Value.ToString();
                        }
                    }
                }
            }
            //si no esta en el listado de los depurados debe de estar en un al ah bl bh
            foreach (var item in misvariables)
            {
                if (item.valor == temporal)
                {
                    return item.variable;
                }
            }
            return "";
        }
        public void TURBOASSEMBLER()
        {
       
            //iniciar variables ensambladores al ah bl bh
            var.variable = "al";
            misvariables.Add(var);
            var = new variablesassembler();
            var.variable = "ah";
            misvariables.Add(var);
            var = new variablesassembler();
            var.variable = "bl";
            misvariables.Add(var);
            var = new variablesassembler();
            var.variable = "bh";
            misvariables.Add(var);
            //termina de variables ensambladores
            try
            {
                string path = @"C:\Users\juanm\Desktop\ensamblador.txt";

                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (FileStream fs = File.Create(path))
                {
                    Addtext(fs, "code segment     ;inicio de un segmento unico \n");
                    Addtext(fs, " assume cs:code,ds:code,ss:code \n");
                    Addtext(fs, " org 100h       ;localidad de inicio del contador \n");
                    Addtext(fs, "  main  proc     ;procedimiento principal \n");
                    Addtext(fs, "   mov ax,cs \n");
                    Addtext(fs, "mov ds,ax   ; INICIO \n ");
                    Addtext(fs, ";PROGRAMA DESDE TRIPLETAS C# SALUDOS  \n");

                    for (int i = 1; i < listatripleta.Count -1; i++)
                    {
                      //ESCRIBE
                        if (listatripleta[i].accion == "ESCRIBE")
                        {
                            if (listatripleta[i].valor.Substring(0,2) == "CD")
                            {

                                letreros letrero = new letreros();
                                letrero.valor = getvalorletrero(listatripleta[i].valor); //
                                listaletreros.Add(letrero);
                                Addtext(fs, " lea dx,letrero" + (listaletreros.Count - 1) + " \n");
                                Addtext(fs, "   mov ah,9h \n");
                                Addtext(fs, "   int 21h \n ");
                                continue;
                            }
                            else
                            {
                                for (int j = 0; j < DGIdentificadores.Rows.Count; j++)
                                {
                                    if (DGIdentificadores.Rows[j].Cells[0].Value.ToString() == listatripleta[i].valor)
                                    {
                                        Addtext(fs, "MOV dx,"+ DGIdentificadores.Rows[j].Cells[1].Value.ToString() + " \n");
                                        continue;
                                    }
                                }
                                Addtext(fs, "  mov ah,02h \n");
                                Addtext(fs, "   int 21h \n ");
                                continue;
                            }

                        }
                        //CAPTURA
                        if (listatripleta[i].accion == "CAPTURA")
                        {
                            Addtext(fs, "  lea dx,a_ascii \n");
                            Addtext(fs, "   mov ah,0ah \n");
                            Addtext(fs, "int 21h\n ");
                            continue;
                        }
                        //CICLO
                        if (listatripleta[i].accion == "CICLO")
                        {
                            int condicion = i +1;
                            int condicion2 = i + 2;//mov x,1
                            int hasta = i + 3;
                            int incremento = i + 4;
                            //temporal
                            if (string.IsNullOrEmpty(valorconstantenumerica(listatripleta[condicion2].valor)))
                            {
                                Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[condicion2].temporal) + "," + valortemporaldepurados(listatripleta[condicion2].valor) + "\n");
                            }
                            else
                            {
                                Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[condicion2].temporal) + "," + valorconstantenumerica(listatripleta[condicion2].valor) + "\n"); //inicializador
                            }
                        
                            Addtext(fs, "MOV " + validartemporal(listatripleta[hasta].temporal) + "," + valorconstantenumerica(listatripleta[hasta].valor) + "\n"); //hasta
                            i += 7;
                            Addtext(fs, "CICLO: \n ");
                            //cuerpo hasta llegar a ciclofin
                            while (listatripleta[i].accion != "CICLOFIN")
                            {//ESCRIBE Y CAPTURA
                                if (listatripleta[i].accion == "ESCRIBE")
                                {
                                    if (listatripleta[i].valor.Substring(0, 2) == "CD")
                                    {

                                        letreros letrero = new letreros();
                                        letrero.valor = getvalorletrero(listatripleta[i].valor); //
                                        listaletreros.Add(letrero);
                                        Addtext(fs, " lea dx,letrero" + (listaletreros.Count - 1) + " \n");
                                        Addtext(fs, "   mov ah,9h \n");
                                        Addtext(fs, "   int 21h \n ");
                                        i++;
                                        continue;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < DGIdentificadores.Rows.Count; j++)
                                        {
                                            if (DGIdentificadores.Rows[j].Cells[0].Value.ToString() == listatripleta[i].valor)
                                            {
                                                Addtext(fs, "MOV dx," + DGIdentificadores.Rows[j].Cells[1].Value.ToString() + " \n");
                                                continue;
                                            }
                                        }
                                        Addtext(fs, "  mov ah,02h \n");
                                        Addtext(fs, "   int 21h \n ");
                                        i++;
                                        continue;
                                    }

                                }
                                if (listatripleta[i].accion == "CAPTURA")
                                {
                                    Addtext(fs, "  lea dx,a_ascii \n");
                                    Addtext(fs, "   mov ah,0ah \n");
                                    Addtext(fs, "int 21h\n ");
                                    i++;
                                    continue;
                                }
                                //VARIABLES NORMALES
                                if ((listatripleta[i].valor.Substring(0, 2) == "ID" && listatripleta[i].accion == "MOV") && (listatripleta[i].temporal == listatripleta[i + 1].temporal))
                                {

                                    if (listatripleta[i + 1].valor.Substring(0, 2) == "TE") // A = TEMPORAL
                                    {
                                        Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[i + 1].temporal) + "," + valortemporaldepurados(listatripleta[i + 1].valor) + "\n");
                                    }
                                    else // A = 4
                                    {
                                        Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[i + 1].temporal) + "," + valorconstantenumerica(listatripleta[i + 1].valor) + "\n");
                                        //mov A,temporal al,bl,ah,bh guardar temporal y variable
                                    }
                                    i++;
                                    limpiarvarensamblador();
                                    continue;
                                }
                                //VALIDAR MULTIPLICACION
                                if (listatripleta[i].accion == "*")
                                {
                                    Addtext(fs, "MOV AL," + valortemporaldepurados(listatripleta[i].temporal)+" \n");
                                    Addtext(fs, "MUL " + valortemporaldepurados(listatripleta[i].valor) + "\n");
                                    Addtext(fs,"MOV "+ valortemporaldepurados(listatripleta[i].temporal) + ",AL"+"\n");
                                    i++;
                                    continue;
                                }
                                if (listatripleta[i].valor.Substring(0, 2) == "TE")
                                {
                                    Addtext(fs, listatripleta[i].accion + " " + valortemporaldepurados(listatripleta[i].temporal) + "," + valortemporaldepurados(listatripleta[i].valor) + "\n");
                                }
                                else
                                {
                                    Addtext(fs, listatripleta[i].accion + " " + validartemporal(listatripleta[i].temporal) + "," + valorconstantenumerica(listatripleta[i].valor) + "\n");
                                }
                                i++;
                            }
                            if (valorconstantenumerica(listatripleta[incremento].valor).Substring(0,1) =="-")
                            {
                                Addtext(fs, "SUB " + valortemporaldepurados(listatripleta[condicion2].temporal) + "," + valorconstantenumerica(listatripleta[incremento].valor).Substring(1) + "\n");
                            }
                            else
                            {
                                Addtext(fs, "ADD " + valortemporaldepurados(listatripleta[condicion2].temporal) + "," + valorconstantenumerica(listatripleta[incremento].valor) + "\n");
                            }
                            Addtext(fs, "CMP " + valortemporaldepurados(listatripleta[condicion2].temporal) + "," + validartemporal(listatripleta[hasta].temporal) + "\n"); //incremento
                            Addtext(fs,  listatripleta[incremento+ 1].accion +" CICLO \n"); //incremento
                            limpiarvarensamblador();
                            continue;
                        }


                        ////TEMPORALMENTE
                        //if (listatripleta[i].accion =="CICLOFIN")
                        //{
                        //    Addtext(fs, "JMP CICLO \n ");
                        //    continue;
                        //}


                        //if (listatripleta[i].accion == "CONDICIONFIN") // temporalmente inserbible
                        //{
                        //    Addtext(fs, "JMP CONDICION \n "); //inserbible
                        //    continue;
                        //}

                        //CONDICION
                        if (listatripleta[i].accion == "CONDICION")
                        {
                            int condicion = i+1;
                            if (listatripleta[condicion].temporal.Substring(0, 2) == "ID")
                            {
                                for (int h = 0; h < DGIdentificadores.Rows.Count; h++)
                                {
                                    if (DGIdentificadores.Rows[h].Cells[0].Value.ToString() == listatripleta[condicion].temporal)
                                    {
                                        Addtext(fs, "CMP " + DGIdentificadores.Rows[h].Cells[1].Value.ToString() + "," + valorconstantenumerica(listatripleta[condicion].valor) + " \n ");
                                        continue;
                                    }
                                }
                            }
                            if (listatripleta[condicion].temporal.Substring(0, 2) == "CE")
                         
                            {
                                Addtext(fs, "CMP " + valorconstantenumerica(listatripleta[condicion].temporal) + "," + valorconstantenumerica(listatripleta[condicion].valor) + " \n ");
                            }

                            if (listatripleta[condicion].temporal.Substring(0,2) == "TE")
                            {
                                Addtext(fs, "CMP "+valortemporaldepurados(listatripleta[condicion].temporal)+","+valorconstantenumerica(listatripleta[condicion].valor)+ " \n ");

                            }
                          
                            Addtext(fs, listatripleta[condicion].accion + " CONDICION \n ");
                            Addtext(fs, "JMP CONTINUAR \n");
                            i += 3;
                            Addtext(fs, "CONDICION: \n ");

                            while (listatripleta[i].accion != "CONDICIONFIN")
                            {
                                //escribe e imprime
                                
                                if (listatripleta[i].accion == "ESCRIBE")
                                {
                                    if (listatripleta[i].valor.Substring(0, 2) == "CD")
                                    {

                                        letreros letrero = new letreros();
                                        letrero.valor = getvalorletrero(listatripleta[i].valor); //
                                        listaletreros.Add(letrero);
                                        Addtext(fs, " lea dx,letrero" + (listaletreros.Count - 1) + " \n");
                                        Addtext(fs, "   mov ah,9h \n");
                                        Addtext(fs, "   int 21h \n ");
                                        i++;
                                        continue;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < DGIdentificadores.Rows.Count; j++)
                                        {
                                            if (DGIdentificadores.Rows[j].Cells[0].Value.ToString() == listatripleta[i].valor)
                                            {
                                                Addtext(fs, "MOV dx," + DGIdentificadores.Rows[j].Cells[1].Value.ToString() + " \n");
                                                continue;
                                            }
                                        }
                                        Addtext(fs, "  mov ah,02h \n");
                                        Addtext(fs, "   int 21h \n ");
                                        i++;
                                        continue;
                                    }

                                }
                                if (listatripleta[i].accion == "CAPTURA")
                                {
                                    Addtext(fs, "  lea dx,A \n");
                                    Addtext(fs, "   mov ah,0ah \n");
                                    Addtext(fs, "int 21h\n ");
                                    i++;
                                    continue;
                                }
                                //VARIABLES NORMALES
                                      if ((listatripleta[i].valor.Substring(0, 2) == "ID" && listatripleta[i].accion == "MOV") && (listatripleta[i].temporal == listatripleta[i + 1].temporal))
                                {

                                    if (listatripleta[i + 1].valor.Substring(0, 2) == "TE") // A = TEMPORAL
                                    {
                                        Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[i + 1].temporal) + "," + valortemporaldepurados(listatripleta[i + 1].valor) + "\n");
                                    }
                                    else // A = 4
                                    {
                                        Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[i + 1].temporal) + "," + valorconstantenumerica(listatripleta[i + 1].valor) + "\n");
                                        //mov A,temporal al,bl,ah,bh guardar temporal y variable
                                    }
                                    i++;
                                    limpiarvarensamblador();
                                    continue;
                                }
                                if (listatripleta[i].valor.Substring(0, 2) == "TE")
                                {
                                    Addtext(fs, listatripleta[i].accion + " " + valortemporaldepurados(listatripleta[i].temporal) + "," + valortemporaldepurados(listatripleta[i].valor) + "\n");
                                }
                                else
                                {
                                    Addtext(fs, listatripleta[i].accion + " " + validartemporal(listatripleta[i].temporal) + "," + valorconstantenumerica(listatripleta[i].valor) + "\n");
                                }
                                i++;
                            }
                            Addtext(fs, "JMP CONTINUAR \n");
                            Addtext(fs, "CONTINUAR: \n ");
                            continue;
                        }
                        //validar identificadores
                        if ((listatripleta[i].valor.Substring(0,2) == "ID" && listatripleta[i].accion == "MOV") && (listatripleta[i].temporal == listatripleta[i+1].temporal))
                        {
                            
                            if (listatripleta[i+1].valor.Substring(0,2) =="TE") // A = TEMPORAL
                            {
                                Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[i+1].temporal) + "," + valortemporaldepurados(listatripleta[i + 1].valor) + "\n");
                            }
                            else // A = 4
                            {
                                Addtext(fs, "MOV " + valortemporaldepurados(listatripleta[i + 1].temporal) + "," + valorconstantenumerica(listatripleta[i+1].valor) + "\n");
                                //mov A,temporal al,bl,ah,bh guardar temporal y variable
                            }
                            i++;
                            limpiarvarensamblador();
                            continue;
                        }
                        if (listatripleta[i].valor.Substring(0,2) == "TE")
                        {
                            Addtext(fs, listatripleta[i].accion + " " + valortemporaldepurados(listatripleta[i].temporal) + "," + valortemporaldepurados(listatripleta[i].valor) + "\n");
                        }
                        else
                        {
                            Addtext(fs, listatripleta[i].accion + " " + validartemporal(listatripleta[i].temporal) + "," + valorconstantenumerica(listatripleta[i].valor) + "\n");
                        }


                    }
                    //termina el programa
                    Addtext(fs, "   mov ah,4ch ;termina el programa main \n");
                    Addtext(fs, "  int 21h   \n");
                    Addtext(fs, "main endp \n ");
                    //variables
                    for (int i = 0; i < listadepurados.Count; i++)
                    {
                        Addtext(fs, valortemporaldepurados(listadepurados[i].Temporal) +" db 0 \n ");
                    }
                    for (int i = 0; i < listaletreros.Count; i++)
                    {
                        Addtext(fs, "letrero"+i.ToString() +" db 0dh,0ah '"+listaletreros[i].valor.Replace('"',' ')+"$' \n ");
                    }
                    //pie final
                    Addtext(fs, "  code ends  \n");
                    Addtext(fs, "  end main  \n");                
                }
                return;
            }
            catch (Exception X)
            {

                throw;
            }
        }
        public void addletrero(letreros letras)
        {
            try
            {
                if (listaletreros.Count > 0)
                {
                    bool repear = false;
                    foreach (var item in listaletreros)
                    {
                        if (item.valor == letras.valor)
                        {
                            repear = true;
                            continue;
                        }
                    }
                    if (!repear) //si no esta repetido
                    {

                        listaletreros.Add(letras);
                        return;
                    }
                }
                listaletreros.Add(letras);
                return;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public string getvalorletrero (string identificador)//DE CADENA01 OBTENER TODA LA CADENA PENDIENTE111111111111111111111111111111111
        {
            try
            {
                for (int i = 0; i < DGCadena.Rows.Count; i++)
                {
                    if (DGCadena.Rows[i].Cells[0].Value.ToString() == identificador)
                    {
                        return DGCadena.Rows[i].Cells[1].Value.ToString();
                    }
                }
                return "ERROR NO SE ENCONTRO EL LETRERO";
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public void iftripleta(string condicion)
        {
            MessageBox.Show("CONDICION: "+ condicion);
            CUADRUPLOS ENCABEZADOCONDICION = new CUADRUPLOS();
            ENCABEZADOCONDICION.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
            ENCABEZADOCONDICION.accion = "CONDICION";
            ENCABEZADOCONDICION.temporal = "TE00";
            ENCABEZADOCONDICION.valor = "";
            listatripleta.Add(ENCABEZADOCONDICION);
            condicion = condicion.Replace("||||", "~");
            var cuerpo = condicion.Split('~');
      
            string OPERADOR = "";
            string condicionneg = "";
            string condicion2 = "";
            int temporal1 = 0;
            bool verdadero = true;
            bool multiplecondicion = false;
            for (int i = 0; i < cuerpo.Count() -1; i++)
            {
                if (i == 0)
                {
                    //encabezado
                    string encabezado = cuerpo[i].Substring(4);
                    string condicion1 = CONDICION(encabezado.Substring(4, 4));
                    condicionneg = CONDICIONNEGADA(encabezado.Substring(4, 4));
                    if (encabezado.Length > 12)
                    {
                        OPERADOR = encabezado.Substring(12,4);
                        condicion2 = CONDICION(encabezado.Substring(20, 4));
                        multiplecondicion = true;
                    }

                    if (multiplecondicion)//hay 2 condiciones
                    {
                        if (OPERADOR == "OPL|") //OPERADOR OR
                        {

                        }
                        else //OPERADOR AND
                        {

                        }
                    }
                    else //1 condicionsolamente
                    {
                        CUADRUPLOS variable = new CUADRUPLOS();
                        variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                        variable.accion = condicion1;
                        variable.temporal = encabezado.Substring(0,4);
                        variable.valor = encabezado.Substring(8, 4);
                        variable.apuntador = variable.memoria + 2; //apuntador temporal. guardar esta variable
                        listatripleta.Add(variable);
                        variable = new CUADRUPLOS();
                        variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                        variable.accion = condicionneg;
                        variable.temporal = encabezado.Substring(0, 4);
                        variable.valor = encabezado.Substring(8, 4);
                        variable.apuntador = variable.memoria + 1; //apuntador temporal. guardar esta variable
                        listatripleta.Add(variable);
                        temporal1 = listatripleta.IndexOf(variable);
                        continue;
                    }
                }
                //HABILITAR ENTRAR AL ELSE DEL IF
                if (cuerpo[i] == "PR22")
                {
                    verdadero = false;  //termino el despapaye tomar el ultimo registro de memoria
                    CUADRUPLOS ELSE = new CUADRUPLOS();
                    ELSE.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                    ELSE.accion = "CONDICIONFIN";
                    ELSE.temporal = "TE00";
                    ELSE.valor = "";
                    listatripleta.Add(ELSE);
                    listatripleta[temporal1].apuntador = listatripleta.Count + 1;

                    continue;
                }
                //CAPTURA
                if (cuerpo[i].Substring(0, 4) == "PR03")
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = listatripleta.Count;
                    variable.accion = "CAPTURA";
                    variable.temporal = "TE00";
                    variable.valor = cuerpo[i].Substring(4, 4);
                    listatripleta.Add(variable);
                    continue;
                }
                //ESCRIBE IMPRIME
                if (cuerpo[i].Substring(0, 4) == "PR07")
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = listatripleta.Count;
                    variable.accion = "ESCRIBE";
                    variable.temporal = "TE00";
                    variable.valor = cuerpo[i].Substring(4, 4);
                    listatripleta.Add(variable);
                    continue;
                }

                if (cuerpo[i].Substring(0, 2) == "ID")
                {
                    depurarnormal id = new depurarnormal();
                    id.ID = cuerpo[i].Substring(0, 4);
                    addlistadepurados(id);
                }
                addtripleta(cadenanormalreplace(cuerpo[i]));

            } // FIN CUERPO DE LA CONDICION
            if (verdadero) //si no hubo else
            {
                CUADRUPLOS ELSE = new CUADRUPLOS();
                ELSE.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                ELSE.accion = "CONDICIONFIN";
                ELSE.temporal = "TE00";
                ELSE.valor = "";
                listatripleta.Add(ELSE);
                listatripleta[temporal1].apuntador = listatripleta.Count + 1;
             
            }
           

        }
        public string ACCION(string OPA)
        {
            switch (OPA)
            {
                case "OPA+":
                    return "ADD";
                    break;
                case "OPA-":
                    return "SUB";
                    break;
                case "OPA=":
                    return "MOV";
                    break;
                case "OPA/":
                    return "/";
                    break;
                case "OPA*":
                    return "*";
                    break;
                default:
                    return "MOV";
                    break;
            }

        }
        public string CONDICION(string opr)
        {
            switch (opr)
            {
                case "OR>>":
                    return "JA";
                    break;
                case "OR<<":
                    return "JB";
                    break;
                case "OR==":
                    return "JE";
                    break;
                default:
                    return "JE";
                    break;
            }
        }
        public string CONDICIONNEGADA(string opr)
        {
            switch (opr)
            {
                case "OR>>":
                    return "JB";
                    break;
                case "OR<<":
                    return "JA";
                    break;
                case "OR==":
                    return "JNE";
                    break;
                default:
                    return "JE";
                    break;
            }
        }
        public string cadenanormalreplace(string normal) {
            try
            {
                if (listadepurados.Count > 0)
                {
                    for (int i = 0; i < normal.Length; i+=4)
                    {
                        string IDactual = normal.Substring(i, 4);
                        if (IDactual.Substring(0,2) == "ID")
                        {
                            foreach (var item in listadepurados)
                            {
                                if (IDactual == item.ID)
                                {
                                    if (!string.IsNullOrEmpty(item.Temporal))
                                    {
                                        normal = normal.Replace(IDactual, item.Temporal);
                                    }
                                }
                            }
                        }
                        
                    }
                    
                }
                return normal;
            }
            catch (Exception x)
            {

                throw;
            }
        }
        public void addtripleta(string normal)
        {
            try
            {
                
                int i = 0;
                string numeros = "";
                string datos = "";
                if (normal.Length == 4)
                {
                    depurarnormal mitemp = new depurarnormal(); //para poder insertarlo debe de existir vacio el temporal
                    if (string.IsNullOrEmpty(listadepurados[listadepurados.Count - 1].Temporal))
                    {
                        listadepurados[listadepurados.Count - 1].Temporal = normal;
                        return;
                    }
                    else
                    {
                        return;
                    }
                    
                   
                }
                while (normal.Substring(i,3) != "OPA")
                {
                    numeros += normal.Substring(i, 4);
                    i += 4;                   
                }
                
                numeros += normal.Substring(i, 4);
                datos = numeros.Substring(i - 8);
                if (datos.Substring(0,2) == "TE")
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                    variable.accion = ACCION(datos.Substring(8,4));
                    variable.temporal = datos.Substring(0, 4);
                    variable.valor = datos.Substring(4, 4);
                    listatripleta.Add(variable);
                    //remplazar el los datos con el Temporal y mandar a llamar otra vez
                    normal = normal.Replace(datos, variable.temporal);
                    addtripleta(normal);
                }
                else
                {
                    //TE00
                    CUADRUPLOS variable = new CUADRUPLOS();
                    if (!(listatripleta.Count > 0)) //lista vacia
                    {
                        variable.memoria = 1;
                        variable.temporal = "TE01";
                        variable.accion = "MOV";
                        variable.valor = datos.Substring(0, 4);
                        listatripleta.Add(variable);
                       normal = normal.Replace(variable.valor, "TE01");
                        addtripleta(normal);

                    }
                    else
                    {
                        //si no esta vacia y el primer token no es un TEMPORAL
                        if (!(datos.Substring(0,2) == "TE"))
                        {
                            variable.accion = "MOV";
                            var temporalactual = int.Parse(listatripleta.OrderByDescending(s => s.temporal).Select(s => s.temporal).ToList()[0].Substring(2)) + 1;
                            variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                            variable.temporal = "TE0" + temporalactual.ToString();
                            variable.valor = datos.Substring(0, 4);
                            listatripleta.Add(variable);
                        normal = normal.Replace(datos.Substring(0, 4), variable.temporal);
                            addtripleta(normal);
                        }
                        else
                        {
                            variable.accion = ACCION(datos.Substring(i));
                            var temporalactual = int.Parse(listatripleta.OrderByDescending(s => s.temporal).Select(s => s.temporal).ToList()[0].Substring(2)) + 1;
                            variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                            variable.temporal = "TE0" + temporalactual.ToString();
                            variable.valor = datos.Substring(i - 4, 4);
                        }
                       
                    }
                    
                }
            }
            catch (Exception x)
            {

                throw;
            }
        }       
        public void ciclotripleta(string ciclo)
        {
            CUADRUPLOS ENCABEZADOCICLO = new CUADRUPLOS();
            ENCABEZADOCICLO.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
            ENCABEZADOCICLO.accion = "CICLO";
            ENCABEZADOCICLO.temporal = "TE00";
            ENCABEZADOCICLO.valor = "";
            listatripleta.Add(ENCABEZADOCICLO);
            MessageBox.Show("ciclo "+ciclo);
            
            ciclo = ciclo.Replace("||||","|");
            var cuerpo = ciclo.Split('|');
            string t1 = "";
            string t2 = "";
            string t3 = "";
            string condicion = "";
            string condicionneg = "";
            int memoriatrue = 0;
            string encabezado = cuerpo[0];
            for (int i = 0; i < encabezado.Length; i+=4)
            {
                if (encabezado.Substring(i,4) == "PR04")
                {
                    string iniciador = "";
                    //TOMAR INICIADOR
                    while (encabezado.Substring(i+4,4) != "PR25")
                    {
                        iniciador += encabezado.Substring(i + 4, 4);
                        i += 4;
                    }
                    if (iniciador.Substring(0,2) == "ID")
                    {
                        depurarnormal id = new depurarnormal();
                        id.ID = iniciador.Substring(0, 4);
                        addlistadepurados(id);
                    }
                    addtripleta(cadenanormalreplace(iniciador));
                    var temporalactual = int.Parse(listatripleta.OrderByDescending(s => s.temporal).Select(s => s.temporal).ToList()[0].Substring(2));
                    t1 = "TE0" + temporalactual.ToString();
                }
                if (encabezado.Substring(i, 4) == "PR25") //pr25ID00OR><CE01 
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    var temporalactual = int.Parse(listatripleta.OrderByDescending(s => s.temporal).Select(s => s.temporal).ToList()[0].Substring(2)) + 1;
                    variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                    variable.accion = "MOV";
                    variable.temporal = "TE0" + temporalactual.ToString();
                    t2 = variable.temporal;
                    variable.valor = encabezado.Substring(i+12,4);
                    listatripleta.Add(variable);
                    condicion = CONDICION(encabezado.Substring(i+8,4));
                    condicionneg = CONDICIONNEGADA(encabezado.Substring(i + 8, 4));

                }
                if (encabezado.Substring(i, 4) == "PR17")
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    var temporalactual = int.Parse(listatripleta.OrderByDescending(s => s.temporal).Select(s => s.temporal).ToList()[0].Substring(2)) + 1;
                    variable.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
                    variable.accion = "MOV";
                    variable.temporal = "TE0" + temporalactual.ToString();
                    variable.valor = encabezado.Substring(i +4, 4);
                    listatripleta.Add(variable);
                    t3 = variable.temporal;
                }
            }
            //condicion para el ciclo verdadera
            CUADRUPLOS condicionciclotrue = new CUADRUPLOS();
            condicionciclotrue.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
            condicionciclotrue.accion = condicion;
            condicionciclotrue.temporal = t1;
            condicionciclotrue.valor = t2;
            condicionciclotrue.apuntador = condicionciclotrue.memoria + 2;
            listatripleta.Add(condicionciclotrue);

            //condicion para el ciclo verdadera
            CUADRUPLOS condicionciclofalse = new CUADRUPLOS();
            condicionciclofalse.memoria = int.Parse(listatripleta.OrderByDescending(s => s.memoria).Select(s => s.memoria).ToList()[0].ToString()) + 1;
            condicionciclofalse.accion = condicionneg;
            condicionciclofalse.temporal = t1;
            condicionciclofalse.valor = t2;
            condicionciclofalse.apuntador = condicionciclotrue.memoria + 1; //apuntador temporal.
            listatripleta.Add(condicionciclofalse);
            memoriatrue = listatripleta.IndexOf(condicionciclofalse);//guardar posicion del ciclo falso para hacer el salto mas adelante.
           
            for (int i = 1; i < cuerpo.Count() -1; i++)
            {
                //CAPTURA
                if (cuerpo[i].Substring(0, 4) == "PR03")
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = listatripleta.Count;
                    variable.accion = "CAPTURA";
                    variable.temporal = "TE00";
                    variable.valor = cuerpo[i].Substring(4, 4);
                    listatripleta.Add(variable);
                    continue;
                }
                //ESCRIBE IMPRIME
                if (cuerpo[i].Substring(0, 4) == "PR07")
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = listatripleta.Count;
                    variable.accion = "ESCRIBE";
                    variable.temporal = "TE00";
                    variable.valor = cuerpo[i].Substring(4, 4);
                    listatripleta.Add(variable);
                    continue;
                }

                if (cuerpo[i].Substring(0, 2) == "ID")
                {
                    depurarnormal id = new depurarnormal();
                    id.ID = cuerpo[i].Substring(0, 4);
                    addlistadepurados(id);
                }
                addtripleta(cadenanormalreplace(cuerpo[i]));
            }
            //nota agregar un loop para regresar la condicion.
            CUADRUPLOS finalciclo = new CUADRUPLOS();
            finalciclo.memoria = listatripleta.Count;
            finalciclo.accion = "CICLOFIN";
            finalciclo.temporal = "TE00";
            finalciclo.valor = "";
            listatripleta.Add(finalciclo);
            listatripleta[memoriatrue].apuntador = listatripleta.Count +1; //redireccionamos el apuntador a la nueva localidad de memoria en false.
             
        }
        public bool addlistadepurados(depurarnormal normal)
        {
            try
            {
                if (listadepurados.Count > 0)
                {
                    bool repetido = false;
                    foreach (var item in listadepurados)
                    {
                        if (normal.ID == item.ID)
                        {
                            repetido = true;
                        }
                    }
                    if (!repetido)
                    {
                        listadepurados.Add(normal);
                    }
                    return true;
                }
                listadepurados.Add(normal);
                return true;
            }
            catch (Exception x)
            {
                return false;
            }
        }
        
        public void TRIPLETA(string prefijos)
        {
            for (int i = 0; i < prefijos.Length; i += 4)
            {
                string tokenactual = prefijos.Substring(i, 4);
                //validad CONDICION
                if (tokenactual == "PR21")
                {
                    string condicion = "";
                    while (tokenactual != "PR12")
                    {
                        tokenactual = prefijos.Substring(i, 4);
                        condicion += tokenactual;
                        i += 4;
                    }
                    //metodo que añade el if a la tripleta
                    iftripleta(condicion.Replace("PR12",""));
                    tripletas.DataSource = null;
                    tripletas.DataSource = listatripleta;
                    continue;
                }

                //CICLOS
                if (tokenactual == "PR04")
                {
                    string ciclo = "";
                    while (tokenactual != "PR09")
                    {
                        tokenactual = prefijos.Substring(i, 4);
                        ciclo += tokenactual;
                        i += 4;
                    }
                    //metodo que añade el if a la tripleta
                    ciclotripleta(ciclo.Replace("PR09",""));
                    tripletas.DataSource = null;
                    tripletas.DataSource = listatripleta;
                    continue;                
                }
                //INICIO
                if (tokenactual == "PR16" && i == 0)
                {
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = 0;
                    variable.accion = "INICIO";
                    variable.temporal = "TE00";
                    variable.valor = "INICIO";
                    listatripleta.Add(variable);
                    i += 4;
                    continue;
                }
                //FIN
                if (tokenactual == "PR10")
                {
                    i += 4;
                    continue;
                }
                //CAPTURA
                if (tokenactual == "PR03")
                {
                    i += 4;
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = listatripleta.Count;
                    variable.accion = "CAPTURA";
                    variable.temporal = "TE00";
                    variable.valor = prefijos.Substring(i, 4);
                    listatripleta.Add(variable);
                    i += 4;
                    continue;
                }
                //ESCRIBE IMPRIME
                if (tokenactual == "PR07")
                {
                    i += 4;
                    
                    CUADRUPLOS variable = new CUADRUPLOS();
                    variable.memoria = listatripleta.Count;
                    variable.accion = "ESCRIBE";
                    variable.temporal = "TE00";
                    variable.valor = prefijos.Substring(i,4);
                    listatripleta.Add(variable);
                    i += 4;
                    continue;
                }
                string prefijonormal ="";
                  //validar que no sea ninguna otra instruccion.
                while (tokenactual != "||||")
                {
                    tokenactual = prefijos.Substring(i, 4);
                    prefijonormal += tokenactual;
                    i += 4;
                }
               
                if (prefijonormal.Replace("||||", "").Substring(0, 2) == "ID")
                {
                    depurarnormal id = new depurarnormal();
                    id.ID = prefijonormal.Replace("||||", "").Substring(0, 4);
                    addlistadepurados(id);
                }
                addtripleta(cadenanormalreplace(prefijonormal.Replace("||||", "")));
                tripletas.DataSource = null;
                tripletas.DataSource = listatripleta;
                i -= 4;
                //SENTENCIAS NORMALES. añadir a tripletas

            }
           
        }

        #endregion

        #region mierda
        private void guardarCodigo_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {

                    sw.Write(richTextBox1.Text);
                    // richTextBox1.Clear();
                }

            }
        }

        private void guardarTokens_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {

                    sw.Write(richTextBox2.Text);
                    // richTextBox2.Clear();
                }

            }
        }

        private void menuTabla_Click(object sender, EventArgs e)
        {
            if (click == 0)
            {
                btnSiguiente.Visible = false;
                panel1.Height = this.Height;
                panel1.Width = this.Width;
                panel1.Visible = true;
                click++;

            }
            else
            {
                panel1.Visible = false;
                btnSiguiente.Visible = true;
                click = 0;
            }
        }
        private void DeterminarToken(string token, string palabra, char salto)//metodo para determinnar las categorias en la tabla de tokens
        {
            palabra = palabra.Trim();
            if (token.Contains("OR"))
            {
                //OPERADOR RELACIONAL
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + "\t\tOPERADOR RELACIONAL\n";
                DGTokens.Rows.Add(token, "OPERADOR RELACIONAL");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("PR"))
            {
                //Palabra reservada

                DGTokens.Rows.Add(token, "PALABRA RESERVADA");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("CE") || token.Contains("CR"))
            {

                contNum = AgregarLista(listaCNENs, palabra, token, salto, contNum, DGConstantesNum);


            }
            else if (token.Contains("CAE"))
            {
                //CARACTER ESPECIAL
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + "\t\tCARACTER ESPECIAL\n";
                DGTokens.Rows.Add(token, "CARACTER ESPECIAL");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("OPA"))
            {
                //OPERADOR ARITMETICO
                //richTextBox2.Text = richTextBox2.Text + "\t" + token + "\t\tOPERADOR ARITMETICO\n";
                DGTokens.Rows.Add(token, "OPERADOR ARITMETICO");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }
            else if (token.Contains("OPL"))
            {
                //OPERADOR LOGICO
                //richTextBox2.Text = richTextBox2.Text + "\t " + token + "\t\tOPERADOR LOGICO\n";
                DGTokens.Rows.Add(token, "OPERADOR LOGICO");
                richTextBox2.Text = richTextBox2.Text + token + salto;
            }

            else if (token == "CD")
            {

                ContCade = AgregarLista(listaCADEs, palabra, token, salto, ContCade, DGCadena);
                //}
            }

            else if (token == "ID")
            {
                IDcontador = AgregarLista(listaIDs, palabra, token, salto, IDcontador, DGIdentificadores);
            }
        }

        private int AgregarLista(List<string> lista, string palabra, string token, char salto, int contador, DataGridView mDataGrid)
        {
            if (lista.Count() > 0)//si la lista de ids es menor a cero entra aqui
            {

                if (BuscarID(palabra, lista) == "") // si es igual a vacio es que no existe ese id por lo tanto se da de alta 
                {
                    contador++;
                    // richTextBox2.Text = richTextBox2.Text + "\t " + token +" "+IDcontador +" \t\tIDENTIFICADOR \t\t          " + palabra + "\n";

                    if (contador < 10)
                    {
                        lista.Add(palabra + "," + token + "0" + contador);
                        richTextBox2.Text = richTextBox2.Text + token + "0" + contador + salto;
                        mDataGrid.Rows.Add(token + "0" + contador, palabra);
                    }

                    else
                    {
                        lista.Add(palabra + "," + token + contador);
                        richTextBox2.Text = richTextBox2.Text + token + contador + salto;
                        mDataGrid.Rows.Add(token + contador, palabra);
                    }

                }
                else
                {
                    //buscar en una lista de id y poneer todo
                    richTextBox2.Text = richTextBox2.Text + BuscarID(palabra, lista) + salto;
                }

            }
            else
            {
                //ID
                contador++;
                // richTextBox2.Text = richTextBox2.Text + "\t " + token +" "+IDcontador +" \t\tIDENTIFICADOR \t\t          " + palabra + "\n";


                if (contador < 10)
                {
                    lista.Add(palabra + "," + token + "0" + contador);
                    richTextBox2.Text = richTextBox2.Text + token + "0" + contador + salto;
                    mDataGrid.Rows.Add(token + "0" + contador, palabra);
                }

                else
                {
                    lista.Add(palabra + "," + token + contador);
                    richTextBox2.Text = richTextBox2.Text + token + contador + salto;
                    mDataGrid.Rows.Add(token + contador, palabra);
                }
            }
            return contador;
        }
        private string BuscarID(string id, List<string> lista)//busca si el id leeido ya existia 
        {

            foreach (var item in lista)
            {

                if (item.Substring(0, item.IndexOf(",")) == id)
                {
                    return item.Substring(item.IndexOf(",") + 1);//regresa el id encotrado
                }
            }
            return "";//si no existe regresa una cadena vacia
        }
        private string BuscarID(string id)//busca si el id leeido ya existia 
        {

            foreach (var item in listaIDs)
            {

                if (item.Substring(0, item.IndexOf(",")) == id)
                {
                    return item.Substring(item.IndexOf(",") + 1);//regresa el id encotrado
                }
            }
            return "";//si no existe regresa una cadena vacia
        }
        private string DefinirTipoDatoID(string cadena)
        {
            string cadena2 = "";
            for (int i = 0; i < richTextBox2.Lines.Count(); i++)
            {
                cadena2 = richTextBox2.Lines[i].Replace(" ", String.Empty);
                if (cadena2.Contains("CAE$"))
                {
                    string id = cadena2.Substring(cadena2.IndexOf("CAE$") - 4, 4);
                    string tipo = cadena2.Substring(cadena2.IndexOf("CAE$") + 4, 2);

                    for (int j = 0; j < DGIdentificadores.Rows.Count; j++)
                    {
                        
                        if (DGIdentificadores.Rows[j].Cells[0].Value.ToString() == id && DGIdentificadores.Rows[j].Cells[2].Value == null)
                        {
                            if (tipo == "CNE")
                            {
                                DGIdentificadores.Rows[j].Cells[2].Value = "CNEN";
                            }
                            else if (tipo == "CNE")
                            {
                                DGIdentificadores.Rows[j].Cells[2].Value = "CNRE";
                            }
                            else if (tipo == "CD")
                            {
                                DGIdentificadores.Rows[j].Cells[2].Value = "CADE";
                            }
                        }
                    }

                }

            }
            return cadena;
        }
        private string NotacionPrefija(string prefija)
        {
            string cadena = prefija;
            prefija = "";

            for (int cont = 0; cont < cadena.Length; cont += 4)
            {
                string aux = cadena.Substring(cont, 4);
                //operador

                if (aux.Contains("CAE("))
                {

                    string x = VaciarPila(null, true);
                    prefija = prefija + x;
                    pila = pila.Replace(x, "");
                }
                else if (aux.Contains("OPA") || aux.Contains("OR") || aux.Contains("OPL") || aux.Contains("CAE)"))
                {
                    if (pila == "")
                    {
                        pila = aux + pila;

                    }
                    else
                    {
                        if (Jeraquia(aux, false) > Jeraquia(pila.Substring(0, 4), true))
                        {
                            pila = aux + pila;
                        }

                        else
                        {
                            string x = VaciarPila(aux, true);
                            prefija = prefija + x;
                            pila = pila.Replace(x, "");
                            pila = aux;


                        }

                    }

                }
                //operando
                else if (aux.Contains("ID") || aux.Contains("CE") || aux.Contains("CR"))
                {
                    prefija = prefija + aux;
                }

            }
            prefija = prefija + pila;
            pila = "";
            banderapostpre = 0;
            textBox1.Text = prefija;
            return prefija;
        }

        private string NotacionPostfija(string postfija)
        {
            bool parentesis = false;
            string cadena = postfija;
            postfija = "";

            for (int cont = 0; cont < cadena.Length; cont += 4)
            {
                string aux = cadena.Substring(cont, 4);
                //operador

                if (aux.Contains("CAE)"))
                {
                    parentesis = false;
                    string x = VaciarPila(null, false);
                    postfija = postfija + x;
                    pila = pila.Replace(x, "");
                }
                else if (aux.Contains("OPA") || aux.Contains("OR") || aux.Contains("OPL") || aux.Contains("CAE(") || aux.Contains("CAE$"))
                {
                    if (pila == "")
                    {
                        pila = aux + pila;

                    }
                    else
                    {
                        if (Jeraquia(aux, false) > Jeraquia(pila.Substring(0, 4), true))
                        {
                            pila = aux + pila;
                        }

                        else
                        {
                            string x = VaciarPila(aux, false);
                            postfija = postfija + x;
                            pila = pila.Replace(x, "");
                            pila = aux + pila;



                        }

                    }

                }
                //operando
                else if (aux.Contains("ID") || aux.Contains("CE") || aux.Contains("CR"))
                {
                    postfija = postfija + aux;
                }
                else if (aux.Contains("CD"))
                {
                    postfija = postfija + aux;
                }

            }
            postfija = postfija + pila;
            pila = "";
            LinePorLineaAuxiliar.Add(postfija);
            banderapostpre = 1;
            return postfija;

        }

        private string invertirCadena(string cadena)
        {
            string cadenaIvertida = "";
            for (int i = cadena.Length; i > 0; i -= 4)
            {
                cadenaIvertida = cadenaIvertida + cadena.Substring(i - 4, 4);
            }

            return cadenaIvertida;
        }
        private int Jeraquia(string operador, bool pila)
        {
            string[,] TablaOperadores = new string[17, 3] { { "OPA+", "2", "2" },{ "OPA-", "2", "2" },{ "OPA*", "3", "3" },
                                                            { "OPA/", "3", "3" }, { "OPA^", "4", "4" }, { "CAE(", "5", "0" },
                                                            { "CAE)", "5", "0" }, { "OR<<", "1", "1" }, { "OR>>", "1", "1" },
                                                            { "OR<=", "1", "1" }, { "OR>=", "1", "1" }, { "OR==", "1", "1" },
                                                            { "OR<>", "1", "1" }, { "OPL&", "1", "1" }, { "OPL!", "1", "1" },
                                                            { "OPL|", "1", "1" },{ "CAE$", "0", "-1" }};

            for (int i = 0; i < TablaOperadores.Length; i++)
            {
                if (TablaOperadores[i, 0] == operador)
                {
                    return pila == true ? int.Parse(TablaOperadores[i, 2]) : int.Parse(TablaOperadores[i, 1]);
                }
            }
            return -1;

        }
        private string VaciarPila(string exp, bool prefOPost)
        {
            string aux = "";
            for (int i = 0; i < pila.Length; i += 4)
            {
                string f = pila.Substring(i, 4);
                aux = aux + pila.Substring(i, 4);
                if (f == "CAE(" && prefOPost == false)
                {
                    pila = pila.Remove(i, 4);
                    aux = aux.Replace("CAE(", "");
                    return aux;
                }
                if (f == "CAE)" && prefOPost == true)
                {
                    pila = pila.Remove(i, 4);
                    return aux;
                }
                else if (exp != null && Jeraquia(exp, false) >= Jeraquia(pila.Substring(i, 4), true))
                {
                    return aux;
                }

                
                //pila = pila.Remove(i, 4);
            }
            return aux;
        }
        private string Limitantes(string cadena)
        {
            pa = 0;
            string cadenaAUX = null;

            for (
                int QW = 0; QW < cadena.Length; QW += 4)
            {
                if (cadena.Substring(QW, 4).Contains("PR"))
                {
                    pa++;
                }
            }
            for (int i = 0; i < cadena.Length; i += 4)
            {
                if (cadena.Substring(i, 4).Contains("PR") && i < cadena.Length)
                {
                    int aux = cadena.Length;
                    string cadeAXU = "";
                    for (int J = i + 4; J < aux; J += 4)
                    {
                        if (cadena.Substring(J, 4).Contains("PR"))
                        {
                            if (CICLO != "HACER")
                            {
                                LinePorLineaOriginal.Add(cadeAXU);
                            }

                            //cadenaAUX = cadenaAUX + cadena.Substring(i, 4) + "----" + cadeAXU + "----";
                            cadeAXU = "";
                            i = J - 4;
                            break;
                        }
                        else
                        {
                            cadeAXU = cadeAXU + cadena.Substring(J, 4);
                        }
                    }

                    if (cadeAXU != "")
                    {
                        if (CICLO != "HACER")
                        {
                            LinePorLineaOriginal.Add(cadeAXU);
                        }

                        //cadenaAUX = cadenaAUX + cadena.Substring(i, 4) + "----" + cadeAXU + "----";
                    }
                }
                else if (cadena.Substring(i, 4).Contains("ID") && pa != 1)
                {
                    if (CICLO == "HACER" && PASOPORCICLO == 1)
                    {
                        LinePorLineaOriginal.Add(cadena.Substring(i, cadena.Length - i));
                    }
                    else if (CICLO == "EJECUTA" && PASOPORCICLO == 1)
                    {
                        LinePorLineaOriginal.Add(cadena.Substring(i, cadena.Length - i));
                    }
                    else if (!(CICLO == "HACER" && PASOPORCICLO == 1) && !(CICLO == "HACER" && PASOPORCICLO == 1))
                    {
                        LinePorLineaOriginal.Add(cadena.Substring(i, cadena.Length - i));
                    }

                    //cadenaAUX = cadenaAUX + "----" + cadena.Substring(i, cadena.Length) + "----";
                    break;
                }
                //else
                //{
                //    LinePorLineaOriginal.Add(cadena);
                //    //cadenaAUX = cadenaAUX + "----" + cadena.Substring(i, cadena.Length) + "----";
                //    break;
                //}


            }

            return cadenaAUX;
        }

        private string AnalisisTripletas(string cadena) 
        {
            string CadenaOriginal = null;
            for (int i = 0; i < cadena.Length; i++)
            {
                if (cadena.Substring(i, 4) == "----")
                {
                    for (int j = i + 4; j < cadena.Length; j++)
                    {
                        if (cadena.Substring(j, 4) != "----")
                        {
                            CadenaOriginal = cadena.Substring(i + 4, j - 4);
                            i = j - 4;
                            break;
                        }
                    }
                }

                if (CadenaOriginal != null)
                {
                    CadenaOriginal = NotacionPostfija(CadenaOriginal);
                    string cadenaAuxiliar = null, cadenaAuxiliar2 = null;
                    for (int k = 0; k < CadenaOriginal.Length; k += 4)
                    {
                        if (CadenaOriginal.Substring(i, 4).Contains("OPA"))
                        {
                            cadenaAuxiliar2 = CadenaOriginal.Substring(i - 8, i + 4);

                            if (misTripleatas == null)
                            {
                                Tripleta x = new Tripleta("TE01", cadenaAuxiliar2.Substring(0, 4), "CAE$", null);
                                Tripleta y = new Tripleta("TE01", cadenaAuxiliar2.Substring(4, 4), cadenaAuxiliar2.Substring(8, 4), null);
                                misTripleatas.Add(x);
                                misTripleatas.Add(y);
                            }
                            else
                            {
                                //buscar TE01 o algo en la lista
                                foreach (var item in misTripleatas)
                                {
                                    //if (item.DatoObjeto)
                                    //{

                                    //}
                                }
                            }



                            //Cuadruplo y = new Cuadruplo("T1",cadenaAuxiliar2.Substring())
                        }
                        cadenaAuxiliar = cadenaAuxiliar + CadenaOriginal.Substring(i, 4);

                    }
                }
            }
            return cadena;
        }

        private void btntriplos_Click(object sender, EventArgs e)
        {
            dataGridView3.Visible = true;
             string cadena2 = "";

            for (int i = 0; i < richTextBox2.Lines.Count() - 1; i++)
            {
                cadena2 = richTextBox2.Lines[i].Replace(" ", String.Empty);

                if (cadena2.Contains("PR22") || cadena2.Contains("PR12"))
                {

                }
                    if (cadena2.Contains("PR21")&&banderainicioyfin==1)
                {
                    banderainicioyfin = 2;
                    CONTADORDEIF ++;
                }
                else if (cadena2.Contains("PR04") && banderainicioyfin == 1)
                {
                    banderainicioyfin=3;
                }
                else if (cadena2.Contains("PR13") && banderainicioyfin == 1)
                {
                    banderainicioyfin=4;
                }
                
                if (cadena2.Contains("PR09") && banderainicioyfin == 3)
                {
                    if ((richTextBox2.Lines.Count() - 1)-i!=0)
                    {
                        findecadainstruccion.Add(DatObjeto.Count + 2);
                        
                    }
                    
                }
                else if (cadena2.Contains("PR12") && banderainicioyfin == 2)
                {
                    if ((richTextBox2.Lines.Count() - 1) - i != 0)
                    {
                        findecadainstruccion.Add(DatObjeto.Count +1);
                        
                    }

                }
                else if  (cadena2.Contains("PR11") && banderainicioyfin == 4)
                {
                    if ((richTextBox2.Lines.Count() - 1) - i != 0)
                    {
                        findecadainstruccion.Add(DatObjeto.Count + 2);
                        
                    }

                }
                
                if (i>0)
                {
                    if (richTextBox2.Lines[i - 1].Replace(" ", String.Empty).Contains("21"))
                    {
                        StartTRUE.Add(DatObjeto.Count+1);
                        
                    }
                    if (richTextBox2.Lines[i - 1].Replace(" ", String.Empty).Contains("22"))
                    {
                        StartFalse.Add(DatObjeto.Count+1);
                        
                    }
                }
                
                if (cadena2.Substring(0, 4).Contains("PR04"))
                {
                    CICLO = "DESDE";
                    TIPO = CICLO;
                    PASOPORCICLO = 2;
                }
                else if (cadena2.Substring(0, 4).Contains("PR05"))
                {
                    CICLO = "EJECUTA";
                    TIPO = CICLO;
                    PASOPORCICLO = 2;
                }
                else if (cadena2.Substring(0, 4).Contains("PR15"))
                {
                    CICLO = "IMPRIMEUBICACAPTURA";
                    tipodeinstruccion = "imprime";
                    
                }
                else if ( cadena2.Substring(0, 4).Contains("PR03") )
                {
                    CICLO = "IMPRIMEUBICACAPTURA";
                    tipodeinstruccion = "captura";

                }
                else if (cadena2.Substring(0, 4).Contains("PR23"))
                {
                    CICLO = "IMPRIMEUBICACAPTURA";
                    tipodeinstruccion = "ubica";

                }
                else if (cadena2.Substring(0, 4).Contains("PR13"))
                {
                    CICLO = "HACER";
                    TIPO = CICLO;
                    PASOPORCICLO = 2;
                    PRIMERO = 1;
                }
                else if (cadena2.Substring(0, 4).Contains("PR14"))
                {
                    CICLO = "HASTA";
                    TIPO = CICLO;
                    PASOPORCICLO = 2;
                }

                if (TIPO == "DESDE" && (cadena2.Substring(0, 4).Contains("PR09")))
                {
                    for (int yu = 0; yu < DatObjeto.Count; yu++)
                    {
                        if (DatObjeto[yu] == "FINDESDE")
                        {
                            DatObjeto.Add("ET");
                            DatFuente.Add("TRIPLO, " + (yu));
                            Oper.Add("");
                            TIPO = "";
                            break;
                        }

                    }
                }
                if (!(Convert.ToString(richTextBox2.Lines[0].Replace(" ", String.Empty)).Contains("PR13")))
                {


                    if (TIPO == "HACER" && (cadena2.Substring(0, 4).Contains("PR11")))
                    {
                        for (int yu = DatObjeto.Count - 1; yu > 0; yu--)
                        {
                            if (Convert.ToString(Oper[yu]).Contains("OR"))
                            {
                                DatObjeto.Add("ET");
                                DatFuente.Add("TRIPLO, " + (yu + 1));
                                Oper.Add("");
                                TIPO = "";
                                break;
                            }

                        }
                    }
                }
                else {
                    if (TIPO == "HACER" && (cadena2.Substring(0, 4).Contains("PR11")))
                    {
                        for (int yu = 0; yu < DatObjeto.Count; yu++)
                        {
                            if (Convert.ToString(Oper[yu]).Contains("OR"))
                            {
                                DatObjeto.Add("ET");
                                DatFuente.Add("TRIPLO, " + (yu + 1));
                                Oper.Add("");
                                TIPO = "";
                                break;
                            }

                        }
                    }
                }
                string cadenaAUX = Limitantes(cadena2);
                if (cadena2.Contains("PR22") || cadena2.Contains("PR12"))
                {
                    for (int qwe = 0; qwe < DatObjeto.Count; qwe++)
                    {
                        if (Convert.ToString(DatObjeto[qwe]).Contains("FINSINCICLO")|| Convert.ToString(DatObjeto[qwe]).Contains("FIN"))
                        {
                            DatObjeto.Add("ET");
                            DatFuente.Add("findefalse");
                            Oper.Add("R" + (qwe + 1));
                            finprimerif.Add(qwe);
                            break;
                        }
                    }
                   
                        if (CONTADORDEIF != 1)
                    {
                        
                    if (!(richTextBox2.Lines[i - 1].Replace(" ", String.Empty).Contains("PR09")))
                    {

                            for (int PO = DatObjeto.Count - 1; PO > Convert.ToInt32(finprimerif[0]); PO--)
                            {
                                if (Convert.ToString(DatObjeto[PO]).Contains("FINSINCICLO") || Convert.ToString(DatObjeto[PO]).Contains("FIN"))
                                {
                                    DatObjeto.Add("ET");
                                    DatFuente.Add("");
                                    Oper.Add("R" + (PO + 1));
                                    CICLO = "IFANIDADOS";
                                    Oper[PO] = "R" + (Convert.ToInt32(finprimerif[0]) + 1);
                                    agregadoalfindesinciclo = 2;
                                    contadordedireccionamientoafin++;
                                    if (contadordedireccionamientoafin == 2)
                                    {
                                        CONTADORDEIF--;

                                    }

                                    break;
                                }


                            }
                        }
                    else
                        {
                            CONTADORDEIF--;
                        }
                        
                    }
                    else
                    {
                        if (agregadoalfindesinciclo == 2)
                        {
                            agregadoalfindesinciclo--;
                        }
                        else
                        {


                            for (int PO = 0; PO < DatObjeto.Count; PO++)
                            {
                                if (Convert.ToString(DatObjeto[PO]).Contains("FINSINCICLO") || Convert.ToString(DatObjeto[PO]).Contains("FIN"))
                                {
                                    DatObjeto.Add("ET");
                                    DatFuente.Add("");
                                    Oper.Add("R" + (PO + 1));
                                    CICLO = "IFANIDADOS";
                                    break;
                                }


                            }
                        }
                    }


                }
                
                
                PASOPORCICLO = 1;
                //if (cadena2.Substring(0, 4).Contains("PR15"))
                //{

                //}
                if (cadenaAUX != null)
                {
                    //MessageBox.Show(cadenaAUX);

                    //x $ y + 5 ^ 3

                }


                for (int oi = 0; oi < LinePorLineaOriginal.Count; oi++)
                {
                    NotacionPostfija(Convert.ToString(LinePorLineaOriginal[oi]));
                    //textBox1.Text = Convert.ToString(LinePorLineaAuxiliar[i]);
                }
                

                if (CICLO == "")
                {
                    DIFERENTEDECICLO();
                    for (int o=0;o<DatObjeto.Count;o++)
                    {
                        if (DatFuente[o]=="findefalse")
                        {
                            for (int p=0;p<DatObjeto.Count;p++)
                            {
                                if (DatFuente[p]=="TRFALSE")
                                {
                                    
                                    Oper[p] =o+2;
                                    break;
                                }
                            }
                            break;
                        }
                    }
                    
                }
                else if (CICLO == "DESDE")
                {
                    for (int yt = 0; yt < LinePorLineaAuxiliar.Count; yt++)
                    {
                        StartFOR.Add(DatObjeto.Count+1);
                        
                        int desde = 0, hasta = 4;
                        //if (Convert.ToString(LinePorLineaAuxiliar[yt]).Length == 12 && Convert.ToString(LinePorLineaAuxiliar[yt]).Substring(8, 4) == "CAE$")
                        //{
                        //    CadenaAuxiliar2.Add(Convert.ToString(LinePorLineaAuxiliar[yt]).Substring(0, 4));
                        //    CadenaAuxiliar2.Add(Convert.ToString(LinePorLineaAuxiliar[yt]).Substring(4, 4));
                        //    CadenaAuxiliar2.Add(Convert.ToString(LinePorLineaAuxiliar[yt]).Substring(8, 4));
                        //    AGREGARCONTEYTE();
                        //    indicelineaporlineaauxiliar++;
                        //}
                        //else
                        //{
                        DIFERENTEDECICLO();
                        //}

                        for (int yu = 0; yu < DatObjeto.Count; yu++)
                        {
                            if (DatObjeto[yu] == "FINDESDE")
                            {

                                


                                for (int iu = Oper.Count - 1; iu > 0; iu--)
                                {
                                    if (Convert.ToString(Oper[iu]).Contains("OR"))
                                    {
                                        DatObjeto.Insert(yu, "ET");
                                        DatFuente.Insert(yu, "NOTRIPLETA");
                                        Oper.Insert(yu, DatObjeto.Count + 2);

                                        DatObjeto.Insert(yu + 1, DatObjeto[iu]);
                                        DatFuente.Insert(yu + 1, DatObjeto[iu - 1]);
                                        Oper.Insert(yu + 1, "+,R" + (iu + 1));

                                        break;
                                    }

                                }

                                break;
                            }

                        }
                        
                        CadenaOriginal.Clear();
                        CadenaAuxiliar.Clear();
                        CadenaAuxiliar2.Clear();
                        cadena = "";
                        cadenaauxiliar = "";
                        cadenaoriginal = "";
                        pasada = 1;
                        otroopl = 0;

                    }



                }
                else if (CICLO == "HACER")
                {
                    StartWhile.Add(DatObjeto.Count + 1);
                    DIFERENTEDECICLO();


                }
                else if (CICLO=="IMPRIMEUBICACAPTURA")
                {
                    SOLOUNTOKEN = Convert.ToString(LinePorLineaAuxiliar[0]);

                    
                    if (SOLOUNTOKEN.Length == 4)
                    {
                        DatObjeto.Add("");
                        DatFuente.Add(SOLOUNTOKEN);
                        if (tipodeinstruccion=="captura")
                        {
                            Oper.Add("PR03");
                        }
                        else if (tipodeinstruccion=="imprime")
                        {
                            Oper.Add("PR15");
                        }
                        else if (tipodeinstruccion=="ubica")
                        {
                            Oper.Add("PR23");
                        }
                        
                        LinePorLineaAuxiliar.RemoveAt(0);
                        LinePorLineaOriginal.RemoveAt(0);
                        

                    }
                    else
                    {
                        DIFERENTEDECICLO();
                        DatObjeto.Add("");
                        DatFuente.Add(DatObjeto[DatObjeto.Count - 2]); Oper.Add("PR15");
                    }



                    CICLO = "IMPRIME";


                    CadenaOriginal.Clear();
                    CadenaAuxiliar.Clear();
                    CadenaAuxiliar2.Clear();
                    cadena = "";
                    cadenaauxiliar = "";
                    cadenaoriginal = "";
                    pasada = 1;
                    otroopl = 0;

                }
                else if(cadena2.Contains("PR05"))
                {
                    StartDOWHILE.Add(DatObjeto.Count + 1);
                    if (cadena2.Contains("PR05") && ENTRO == 0)
                    {

                        inicioejecuta = DatObjeto.Count;


                        ENTRO = 1;
                    }

                    DIFERENTEDECICLO();
                    if ((richTextBox2.Lines.Count() - 2)>i&&cadena2.Contains("PR14"))
                    {
                        for (int yu = 0; yu < DatObjeto.Count; yu++)
                        {
                            if (Convert.ToString(DatObjeto[yu])==("FIN"))
                            {

                                Oper[yu] =yu+2;
                                break;
                            }

                        }
                    }
                    
                }
                dataGridView3.Rows.Clear();
                dataGridView3.Refresh();
                indice = 1;


                for (int l = 0; l < Oper.Count; l++)
                {
                    if (Convert.ToString(Oper[l]) == "Q")
                    {
                        for (int tr = 0; tr < DatObjeto.Count; tr++)
                        {
                            if (DatObjeto[tr] == "FIN" || DatObjeto[tr] == "FINDESDE")
                            {
                                Oper[l] = tr + 1;
                            }
                        }
                    }
                }
                CICLO = "";
                if ((richTextBox2.Lines.Count() - 2) > i && cadena2.Contains("PR09"))
                {
                    for (int yu = 0; yu < DatObjeto.Count; yu++)
                    {
                        if (Convert.ToString(DatObjeto[yu]) == ("FINDESDE"))
                        {
                            
                                for (int bn = 0; bn < DatObjeto.Count; bn++)
                                {
                                if (richTextBox2.Lines[i + 1].Replace(" ", String.Empty) == "PR22")
                                {
                                    if (DatObjeto[bn] == "FIN" || DatObjeto[bn] == "FINSINCICLO")
                                    {
                                        Oper[yu] = "R" + (bn + 1);
                                        break;
                                    }
                                }
                                else if(Convert.ToString( DatFuente[bn]).Contains("TRIPLO"))
                                {
                                    Oper[yu] = "R" + (bn + 2);
                                    break;
                                }
                                }
                            
                            
                            


                            break;    
                        }
                       
                        
                    }
                }
                

                for (int we = 0; we < findecadainstruccion.Count; we++)
                {
                    for (int q = 0; q < DatObjeto.Count; q++)
                    {

                        if ((richTextBox2.Lines.Count() - 2) > i)
                        {


                            if (Convert.ToString(DatObjeto[q]).Contains("FIN") || Convert.ToString(DatObjeto[q]).Contains("FINSINCICLO"))
                            {
                                if (richTextBox2.Lines[richTextBox2.Lines.Count()-2].Replace(" ", String.Empty)!="PR12")
                                {
                                    Oper[q] = "R" + (Convert.ToInt32( findecadainstruccion[we])+1);
                                    findecadainstruccion.RemoveAt(we);
                                    banderainicioyfin = 1;
                                    break;
                                }
                                
                            }
                            else if (Convert.ToString(DatObjeto[q]).Contains("FINDESDE"))
                            {
                                if (richTextBox2.Lines[richTextBox2.Lines.Count()].Replace(" ", String.Empty) != "PR09")
                                {
                                    Oper[q] = "R" + findecadainstruccion[we];
                                    findecadainstruccion.RemoveAt(we);
                                    banderainicioyfin = 1;
                                    break;
                                }
                            }
                            else if (Convert.ToString(DatObjeto[q]).Contains("FINHACER"))
                            {
                                if (richTextBox2.Lines[richTextBox2.Lines.Count()].Replace(" ", String.Empty) != "PR11")
                                {
                                    Oper[q] = "R" + findecadainstruccion[we];
                                    findecadainstruccion.RemoveAt(we);
                                    banderainicioyfin = 1;
                                    break;
                                }
                            }
                        }
                    }
                    
                }
            }
            //======================================LOCALES=========================================================================
            //AjustarDoWhile();
            //removerBlancos();
            //for (int i = 0; i < DatObjeto.Count; i++)
            //{
            //    if (!DatObjeto[i].Equals("") && !DatFuente[i].Equals("") && !Oper[i].Equals(""))
            //    {
            //        RemoverIguales(DatObjeto[i].ToString(), DatFuente[i].ToString(), Oper[i].ToString(), i);
            //    }
            //}
            //removerBlancos();
            //for (int g = 0; g < DatObjeto.Count; g++)
            //{
            //    if (!DatObjeto[g].Equals("") && !DatFuente[g].Equals("") && !Oper[g].Equals("") && !DatObjeto[g].ToString().Contains("TR"))
            //    {
            //        RemoverSinUso(g, DatObjeto[g].ToString(), DatFuente[g].ToString(), Oper[g].ToString());
            //    }
            //}
            //removerBlancos();
            //for (int g = 0; g < DatObjeto.Count; g++)
            //{
            //    if (!DatObjeto[g].Equals("") && !DatFuente[g].Equals("") && !Oper[g].Equals("") && !DatObjeto[g].ToString().Contains("TR") && !modificados.Exists(t => t.EndsWith(DatObjeto[g].ToString())))
            //    {
            //        g = g + RemplazarOcurrencias(g, DatObjeto[g].ToString(), DatFuente[g].ToString(), Oper[g].ToString());
            //    }
            //}
            //removerBlancos();
            //RenglonesNuevos.Clear();
            //for (int g = 0; g < DatObjeto.Count; g++)
            //{
            //    if (!DatObjeto[g].Equals("") && !DatFuente[g].Equals("") && !Oper[g].Equals("") && !DatObjeto[g].ToString().Contains("TR"))
            //    {
            //        AlgebreMasyPor(g, DatObjeto[g].ToString(), DatFuente[g].ToString(), Oper[g].ToString());
            //    }
            //}
            //removerBlancos();

            //================================================================================================================
            //for (int y = 0; y < DatObjeto.Count; y++)
            //{
            //    for (int t = 0; t < StartTRUE.Count; t++)
            //    {
            //        if (Convert.ToString(DatFuente[y]) == "TRTRUE")
            //        {
            //            Oper[y] = StartTRUE[t];
            //            StartTRUE.RemoveAt(t);
            //            t--;
            //            break;
            //        }
            //    }

            //}
            //for (int y = 0; y < DatObjeto.Count; y++)
            //{
            //    for (int t = 0; t < StartFalse.Count; t++)
            //    {
            //        if (Convert.ToString(DatFuente[y]) == "TRFALSE")
            //        {
            //            for (int ty = StartFalse.Count; ty > 0; ty--)
            //            {
            //                Oper[y] = StartFalse[ty-1];
            //                StartFalse.RemoveAt(ty-1);
            //            }

            //            t--;
            //            break;
            //        }
            //    }

            //}

            for (int o = 0; o < DatObjeto.Count; o++)
            {
                if (DatFuente[o] == "findefalse")
                {
                    DatFuente[o] = "";
                }
            }
                    for (int bn = 0; bn < DatObjeto.Count; bn++)
                {
                    dataGridView3.Rows.Add(indice, DatObjeto[bn], DatFuente[bn], Oper[bn]);
                    indice++;
                }

                CICLO = "";
                
            
            
        }


        //LOCALES
        private void RemoverIguales(string datoObjeto, string datoFuente, string operador, int ultimo)
        {
            Tripleta mTripleta = new Tripleta(datoObjeto, datoFuente, operador, null);
            for (int i = ultimo + 1; i < DatObjeto.Count; i++)
            {
                //Buscar tripletas repetidas
                if (mTripleta.DatoFuente.Equals(DatFuente[i].ToString()) && mTripleta.Operador.Equals(Oper[i].ToString()) && !mTripleta.DatoObjeto.Contains("ID") && !operador.Contains("OR") )//&& !operador.Contains("CAE$"))
                {
                    List<Tripleta> mOriginales = getOperadores(datoObjeto, ultimo);
                    List<Tripleta> mCopias = getOperadores(DatObjeto[i].ToString(), i);
                    if (mCopias.Count == mOriginales.Count)
                    {
                        string aux = DatObjeto[i].ToString();
                        //remplazar donde se utliza
                        for (int j = i; j < DatObjeto.Count; j++)
                        {
                            // == true ? : DatObjeto[j];
                            if (aux.Equals(DatObjeto[j].ToString()))
                            {
                                DatObjeto[j] = "";
                                DatFuente[j] = "";
                                Oper[j] = "";
                            }
                            if (DatFuente[j].ToString().Contains(aux))
                            {
                                DatFuente[j] = DatFuente[j].ToString().Replace(aux, datoObjeto);
                            }

                        }
                    }

                }
            }
        }
        private void RemoverSinUso(int id, string datoObjeto, string datoFuente, string operador)
        {
            bool uso = true, mdatofuente = true;
            //detectar si se usa el temporal
            for (int i = 0; i < DatObjeto.Count; i++)
            {
                if (i != id)
                {
                    if (DatFuente[i].Equals(datoObjeto) || DatObjeto[i].Equals(datoObjeto))
                    {
                        uso = true;

                        break;
                    }

                }
                uso = false;
            }
            //remover lo que no se usa
            if (uso == false)
            {
                for (int j = 0; j < DatObjeto.Count; j++)
                {
                    if (j != id)
                    {
                        if (DatFuente[j].Equals(datoFuente))
                        {
                            mdatofuente = true;
                            break;
                        }
                        mdatofuente = false;
                    }
                }

                for (int i = 0; i < DatObjeto.Count; i++)
                {
                    if (DatObjeto[i].Equals(datoObjeto))
                    {
                        DatObjeto[i] = "";
                        DatFuente[i] = "";
                        Oper[i] = "";
                    }
                    if (DatObjeto[i].Equals(datoFuente) && mdatofuente == false)
                    {
                        DatObjeto[i] = "";
                        DatFuente[i] = "";
                        Oper[i] = "";
                    }
                }
            }
        }
        private int RemplazarOcurrencias(int id, string datoObjeto, string datoFuente, string operador)
        {
            bool bandera = false;
            int renglones = 0;
            string temporalABorar = "";
            for (int i = id + 1; i < DatObjeto.Count; i++)
            {
                if (DatFuente[i].Equals(datoFuente) && DatObjeto[i].ToString().Contains("TE"))
                {
                    bandera = false;
                    List<Tripleta> mOriginales = getOperadores(datoObjeto, id);
                    List<Tripleta> mCopias = getOperadores(DatObjeto[i].ToString(), i);
                    int mayor = mCopias.Count > mOriginales.Count ? mCopias.Count : mOriginales.Count;
                    int contOrig = 0;
                    if (mOriginales.Count <= mCopias.Count)
                    {
                        for (int j = 0; j < mCopias.Count; j++)
                        {
                            if (DatObjeto[i].ToString().Equals(DatObjeto[(j + i)].ToString()))
                            {
                                if (Jeraquia(mCopias[j].Operador, false) > Jeraquia(mOriginales[(contOrig)].Operador, false))
                                {
                                    //si es mayor no se cambia
                                    bandera = false;
                                    break;

                                }

                                else
                                {
                                    bandera = true;
                                    temporalABorar = DatObjeto[i].ToString();
                                    if (contOrig < mOriginales.Count - 1)
                                    {
                                        contOrig++;
                                    }

                                }

                            }

                        }
                        if (bandera == true)
                        {

                            //borra los registros
                            for (int f = 0; f < mOriginales.Count; f++)
                            {
                                if (DatObjeto[f + i].Equals(temporalABorar))
                                {
                                    DatObjeto[f + i] = "";
                                    DatFuente[f + i] = "";
                                    Oper[f + i] = "";
                                }
                            }
                            //cambiar donde se usen los registros
                            string newTE = "";
                            for (int f = id; f < DatObjeto.Count; f++)
                            {
                                if (DatObjeto[f].ToString().Contains(temporalABorar))
                                {
                                    if (te < 9)
                                    {
                                        DatObjeto.Insert(f, "TE0" + te);
                                    }
                                    else
                                    {
                                        DatObjeto.Insert(f, "TE" + te);
                                    }
                                    DatFuente.Insert(f, datoObjeto);
                                    Oper.Insert(f, "CAE$");
                                    DatObjeto[f + 1] = DatObjeto[f];
                                    newTE = "TE0" + te;
                                    modificados.Add(newTE);
                                    RenglonesNuevos.Add(f+1);
                                }
                                else if (DatFuente[f].ToString().Contains(temporalABorar))
                                {
                                    if (newTE.Equals(""))
                                    {
                                        DatFuente[f] = datoObjeto;
                                    }
                                    else
                                    {
                                        DatFuente[f] = newTE;
                                    }

                                }
                            }
                            te++;
                            i = i + mCopias.Count;
                            renglones = mOriginales.Count;
                        }


                    }
                }
            }
            if (datoObjeto.Contains("TE") && renglones == 0)
            {
                renglones = getOperadores(datoObjeto, id).Count;
            }

            return renglones;



        }
        private List<Tripleta> getOperadores(string temporal, int id)
        {
            List<Tripleta> x = new List<Tripleta>();
            for (int i = id; i < DatObjeto.Count; i++)
            {
                if (DatObjeto[i].ToString().Equals(temporal))
                    x.Add(new Tripleta(DatObjeto[i].ToString(), DatFuente[i].ToString(), Oper[i].ToString(), null));
                else
                    break;
            }
            return x;
        }
        private void AlgebreMasyPor(int id, string datoObjeto, string datoFuente, string operador)
        {
            if (operador == "OPA+" || operador == "OPA-")
            {
                if (BuscarValorConstante(datoFuente) == 0)
                {
                    DatObjeto[id] = "";
                    DatFuente[id] = "";
                    Oper[id] = "";
                }
            }
            else if (operador == "OPA*" || operador == "OPA/")
            {
                if (BuscarValorConstante(datoFuente) == 1)
                {
                    DatObjeto[id] = "";
                    DatFuente[id] = "";
                    Oper[id] = "";
                }
            }
        }
        private int BuscarValorConstante(string constante)
        {
            //DGConstantesNum
            for (int i = 0; i < DGConstantesNum.RowCount; i++)
            {
                if (DGConstantesNum.Rows[i].Cells[0].Value.Equals(constante))
                {
                    int valor = int.Parse(DGConstantesNum.Rows[i].Cells[1].Value.ToString());
                    if (valor <= 1)
                    {
                        return valor;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
            return -1;
        }
        private void removerBlancos()
        {
            int contador = 0;
            int blancos = 0;
            for (int j = 0; j < DatObjeto.Count; j++)
            {
                //esto es para los for
                if (DatFuente[j].ToString().Contains("TRIPLO"))
                {
                    int x = int.Parse(DatFuente[j].ToString().Substring(DatFuente[j].ToString().IndexOf(',') + 1));
                    blancos = ContadorBlancos(0, x);
                    if (blancos != 0)
                    {
                        DatFuente[j] = "";
                        DatFuente[j] = "TRIPLO," + (x - blancos);
                    }
                }

                else if (Oper[j].ToString().Contains("+,R"))
                {
                    int x = int.Parse(Oper[j].ToString().Substring(Oper[j].ToString().IndexOf('R') + 1));
                    blancos = ContadorBlancos(j, int.Parse(Oper[j].ToString().Substring(Oper[j].ToString().IndexOf('R') + 1)) - 1) + ContadorBlancos(0, j);
                    if (blancos != 0)
                    {
                        Oper[j] = "";
                        Oper[j] = "+," + (x - blancos);
                    }

                }
                

                else if ((DatFuente[j].ToString().Contains("TRTRUE") && DatObjeto[j].ToString().Contains("ET")))
                {
                    for (int y = 0; y < DatObjeto.Count; y++)
                    {
                        for (int t = 0; t < StartTRUE.Count; t++)
                        {
                            if (Convert.ToString(DatFuente[y]) == "TRTRUE")
                            {
                                blancos = ContadorBlancos(y, int.Parse(StartTRUE[t].ToString()) - 1) + ContadorBlancos(0, y);

                                Oper[y] = Convert.ToString(int.Parse(StartTRUE[t].ToString()) - blancos);
                                StartTRUE[t] = Convert.ToString(int.Parse(StartTRUE[t].ToString()) - blancos);
                                break;
                            }
                        }

                    }
                    //TRfalse
                    for (int y = 0; y < DatObjeto.Count; y++)
                    {
                        for (int t = 0; t < StartFalse.Count; t++)
                        {
                            if (Convert.ToString(DatFuente[y]) == "TRFALSE")
                            {
                                for (int ty = StartFalse.Count; ty > 0; ty--)
                                {
                                    //Oper[y] = StartFalse[ty - 1];
                                    ////StartFalse.RemoveAt(ty - 1);
                                    blancos = ContadorBlancos(y, int.Parse(StartFalse[ty - 1].ToString())) + ContadorBlancos(0, y);
                                    Oper[y] = Convert.ToString(int.Parse(StartFalse[ty - 1].ToString()) - blancos);
                                    StartFalse[ty - 1] = Oper[y].ToString();
                                }
                                break;
                            }
                        }

                    }
                }
                else if (DatObjeto[j].ToString().Contains("TR") || DatFuente[j].ToString().Contains("NOTRIPLETA"))
                {
                    int x = int.Parse(Oper[j].ToString());
                    blancos = ContadorBlancos(j, int.Parse(Oper[j].ToString()) - 1) + ContadorBlancos(0, j);
                    if (blancos != 0)
                    {
                        Oper[j] = "";
                        Oper[j] = "" + (x - blancos);
                    }
                }
                else if (DatObjeto[j].ToString().Contains("FIN") && Oper[j].ToString().Contains("R") && Oper[j].ToString().Contains("OR") == false && Oper[j].ToString().Contains("+,R") == false && Oper[j].ToString().Contains("PR") == false)//
                {
                    int x = int.Parse(Oper[j].ToString().Substring(Oper[j].ToString().IndexOf('R') + 1));
                    int y = x > j ? j : x;
                    blancos = ContadorBlancos(j, int.Parse(Oper[j].ToString().Substring(Oper[j].ToString().IndexOf('R') + 1)) - 1) + ContadorBlancos(0, y);
                    if (blancos != 0)
                    {
                        Oper[j] = "";
                        Oper[j] = "R" + (x - blancos);
                    }
                }

               


            }
            for (int i = 0; i < DatObjeto.Count; i++)
            {

                if (DatObjeto[i].Equals("") && DatFuente[i].Equals("") && Oper[i].Equals(""))
                {
                    DatObjeto.RemoveAt(i);
                    DatFuente.RemoveAt(i);
                    Oper.RemoveAt(i);
                    i--;
                }
            }


        }
        private int ContadorBlancos(int id, int valoraBuscar)
        {
            int contador = 0;
           
            for (int i = id; i < DatObjeto.Count; i++)
            {
                if (DatObjeto[i].Equals("") && DatFuente[i].Equals("") && Oper[i].Equals("") && i < valoraBuscar)
                {
                    contador++;
                }
               
            }
            if (RenglonesNuevos.Count != 0)
            {
                for (int g = 0; g < RenglonesNuevos.Count; g++)
                {
                    if ((int)RenglonesNuevos[g] < valoraBuscar && (int)RenglonesNuevos[g] > id)
                    {
                        contador--;
                    }
                }
            }
            return contador;
        }
        private void cambiarValores(int blancos, int id)
        {
            for (int i = id; i < DatObjeto.Count; i++)
            {
                if (DatObjeto[i].ToString().Contains("TR") || DatFuente[i].ToString().Contains("TR"))
                {
                    int x = int.Parse(Oper[i].ToString());
                    Oper[i] = "";
                    Oper[i] = "" + (x - blancos);
                }
            }
        }
        private void AjustarDoWhile()
        {
            List<Tripleta> mTripletas = new List<Tripleta>();
            if (StartDOWHILE.Count != 0)
            {
                for (int i = 0; i < StartDOWHILE.Count; i++)
                {
                    int x = int.Parse(StartDOWHILE[i + 1].ToString());
                    if (seUsa(int.Parse(StartDOWHILE[i].ToString()) - 1, int.Parse(StartDOWHILE[i + 1].ToString()) - 1) == false)
                    {
                        for (int j = x - 1; j < DatObjeto.Count; j++)
                        {
                            if (DatObjeto[j].ToString().Contains("TR"))
                            {
                                int aux = int.Parse(StartDOWHILE[i].ToString()) - 1;
                                foreach (var item in mTripletas)
                                {
                                    DatObjeto.Insert(aux, item.DatoObjeto);
                                    DatFuente.Insert(aux, item.DatoFuente);
                                    Oper.Insert(aux, item.Operador);
                                    aux++;
                                }
                                Oper[j + mTripletas.Count] = Convert.ToString(int.Parse(Oper[j + mTripletas.Count].ToString()) + mTripletas.Count);

                                i++;
                                mTripletas.Clear();
                                break;
                            }

                            if (!DatObjeto[j + 1].ToString().Contains("TR"))
                            {
                                mTripletas.Add(new Tripleta(DatObjeto[j].ToString(), DatFuente[j].ToString(), Oper[j].ToString(), null));
                                DatObjeto[j] = "";
                                DatFuente[j] = "";
                                Oper[j] = "";
                            }
                        }
                    }
                    else
                    {
                        i++;
                    }
                }
            }
            removerBlancos();
        }

        private bool seUsa(int inicio, int fin)
        {
            for (int i = inicio; i < fin; i++)
            {
                if (DatObjeto[i].Equals(DatObjeto[fin].ToString()) || (DatFuente[i].Equals(DatObjeto[fin].ToString())) || DatObjeto[i].Equals(DatFuente[fin].ToString()) || (DatFuente[i].Equals(DatFuente[fin].ToString())))
                {
                    return true;
                }
            }
            return false;
        }
        //fin locales
        private void DIFERENTEDECICLO()
        {
            for (int s = indicelineaporlineaauxiliar; s < LinePorLineaAuxiliar.Count; s++)
            {
                int desde = 0, hasta = 4;
                cadenaoriginal = Convert.ToString(LinePorLineaAuxiliar[s]);
                do
                {

                    CadenaOriginal.Add(cadenaoriginal.Substring(desde, hasta));
                    desde = desde + hasta;


                } while (!(desde == cadenaoriginal.Length));
                //MessageBox.Show(cadenaoriginal);
                int del0al9 = 1;
                for (int i = 0; i < CadenaOriginal.Count; i++)
                {


                    string cadeoriginal = Convert.ToString(CadenaOriginal[i]);
                    if (cadeoriginal.Contains("OR"))
                    {

                        int decimos = 1;
                        //Si con tienen lo agrego y sigo con los pasos

                        CadenaAuxiliar.Add(cadeoriginal);

                        CadenaAuxiliar2.Add(CadenaAuxiliar[CadenaAuxiliar.Count - 3]);
                        CadenaAuxiliar2.Add(CadenaAuxiliar[CadenaAuxiliar.Count - 2]);
                        CadenaAuxiliar2.Add(CadenaAuxiliar[CadenaAuxiliar.Count - 1]);
                        string detectarTE = "";

                        detectarTE = Convert.ToString(CadenaAuxiliar2[1]);




                        if (cadeoriginal.Contains("OR"))
                        {

                            AGREGARCONTEYTE();


                            //if (paso == 0)
                            //{
                            //    for (int n = 0; n < CadenaOriginal.Count; n++)
                            //    {
                            //        if (Convert.ToString(CadenaOriginal[n]) == "OPL&")
                            //        {
                            //            cantidaddeoperadoresAND++;

                            //        }
                            //        else if (Convert.ToString(CadenaOriginal[n]) == "OPL|")
                            //        {
                            //            cantidaddeoperadoresOR++;

                            //        }
                            //    }
                            for (int n = indicecadenaauxiliar + 1; n < CadenaOriginal.Count; n++)
                            {
                                if (Convert.ToString(CadenaOriginal[n]) == "OPL&")
                                {
                                    primeroopl = "&";
                                    tipo = "OPL&";
                                    checarotroopl = n;
                                    if (doblecomparacion == 1)
                                    {
                                        indicecadenaauxiliar = n;
                                        doblecomparacion = 0;
                                    }






                                    break;
                                }

                                else if (Convert.ToString(CadenaOriginal[n]) == "OPL|")
                                {


                                    tipo = "OPL|";
                                    checarotroopl = n;
                                    if (doblecomparacion == 1)
                                    {
                                        indicecadenaauxiliar = n;
                                        doblecomparacion = 0;
                                    }
                                    break;
                                }
                                else
                                {
                                    tipo = "";
                                }
                            }


                            //}

                            if (tipo == "OPL&")
                            {

                                doblecomparacion++;

                                string objetoss = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                                string fuentess = Convert.ToString(DatFuente[DatFuente.Count - 1]);
                                dataGridView3.Rows.Add(indice, objetoss, fuentess, Oper[Oper.Count - 1]);
                                indice++;
                                if (checarotroopl < CadenaOriginal.Count)
                                {

                                    esopl = false;

                                }
                                for (int n = checarotroopl + 1; n < CadenaOriginal.Count; n++)
                                {
                                    if (Convert.ToString(CadenaOriginal[n]) == "OPL&")
                                    {
                                        esopl = true;


                                        break;
                                    }

                                    else if (Convert.ToString(CadenaOriginal[n]) == "OPL|")
                                    {
                                        esopl = false;
                                        otroopl = 1;

                                        break;
                                    }

                                }

                                if (esopl)
                                {
                                    Oper.Add(DatObjeto.Count + 3);
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("TRUE");
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("FALSE");
                                    Oper.Add("FALSEANDTOOR");
                                }
                                else
                                {
                                    if (i + 1 == checarotroopl)
                                    {
                                        Oper.Add("w");
                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("TRUE");
                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("FALSE");
                                        Oper.Add("FALSEANDTOOR");
                                    }
                                    else
                                    {
                                        Oper.Add(DatObjeto.Count + 3);
                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("TRUE");

                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("FALSE");
                                        Oper.Add("FALSEANDTOOR");
                                    }
                                }
                                objetoss = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                                fuentess = Convert.ToString(DatFuente[DatFuente.Count - 1]);
                                //for (int f = 0; f < DatFuente.Count; f++)
                                //{
                                //    string fal = Convert.ToString(DatFuente[f]);
                                //    if (fal.Contains("TRFALSE"))
                                //    {
                                //        Oper.Add(f);
                                //    }
                                //}
                                TR++;
                                dataGridView3.Rows.Add(indice, objetoss, fuentess, "Q");

                                indice++;

                                //for (int er = 0; er < DatObjeto.Count; er++)
                                //{
                                //    if (Oper[er]=="w")
                                //    {
                                //        Oper[er] = DatObjeto.Count + 1;
                                //    }
                                //}

                                CadenaAuxiliar.Clear();
                                CadenaAuxiliar2.Clear();
                                cadena = "";
                                cadenaauxiliar = "";
                                cadenaoriginal = "";
                                cantidaddeoperadoresAND--;
                                pasadaOPL = 0;
                                pasada = 1;

                            }
                            else if (tipo == "OPL|")
                            {

                                doblecomparacion++;


                                string objetoss = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                                string fuentess = Convert.ToString(DatFuente[DatFuente.Count - 1]);
                                dataGridView3.Rows.Add(indice, objetoss, fuentess, Oper[Oper.Count - 1]);
                                indice++;
                                if (checarotroopl < CadenaOriginal.Count)
                                {

                                    esopl = false;

                                }
                                for (int n = checarotroopl + 1; n < CadenaOriginal.Count; n++)
                                {
                                    if (Convert.ToString(CadenaOriginal[n]) == "OPL&")
                                    {
                                        esopl = false;

                                        otroopl = 1;
                                        break;
                                    }

                                    else if (Convert.ToString(CadenaOriginal[n]) == "OPL|")
                                    {
                                        esopl = true;


                                        break;
                                    }
                                }

                                if (esopl)
                                {
                                    Oper.Add("directoatrue");
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("TRUE");
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("FALSE");
                                    Oper.Add(DatObjeto.Count + 1);
                                }
                                else
                                {
                                    if (i + 1 == checarotroopl)
                                    {
                                        Oper.Add("w");
                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("TRUE");
                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("FALSE");
                                        Oper.Add("Q");
                                    }
                                    else
                                    {
                                        Oper.Add("w");
                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("TRUE");

                                        DatObjeto.Add("TR" + TR);
                                        DatFuente.Add("FALSE");
                                        Oper.Add(DatFuente.Count + 1);
                                    }
                                }

                                objetoss = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                                fuentess = Convert.ToString(DatFuente[DatFuente.Count - 1]);
                                //for (int f = 0; f < DatFuente.Count; f++)
                                //{
                                //    string fal = Convert.ToString(DatFuente[f]);
                                //    if (fal.Contains("TRFALSE"))
                                //    {
                                //        Oper.Add(f);
                                //    }
                                //}
                                TR++;
                                dataGridView3.Rows.Add(indice, objetoss, fuentess, "Q");

                                indice++;


                                CadenaAuxiliar.Clear();
                                CadenaAuxiliar2.Clear();
                                cadena = "";
                                cadenaauxiliar = "";
                                cadenaoriginal = "";
                                cantidaddeoperadoresOR--;
                                pasadaOPL = 0;
                                pasada = 1;

                            }
                            else if (CadenaOriginal.Count - 1 == i)
                            {
                                indice = 1;
                                
                                 if (CICLO == "")
                                {


                                    Oper.Add(DatObjeto.Count + 3);
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("TRUE");

                                    string objetoss = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                                    string fuentess = Convert.ToString(DatFuente[DatFuente.Count - 1]);
                                    dataGridView3.Rows.Add(indice, objetoss, fuentess, Oper[Oper.Count - 1]);
                                    indice++;
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("FALSE");
                                    Oper.Add("Q");

                                    objetoss = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                                    fuentess = Convert.ToString(DatFuente[DatFuente.Count - 1]);
                                    //for (int f = 0; f < DatFuente.Count; f++)
                                    //{
                                    //    string fal = Convert.ToString(DatFuente[f]);
                                    //    if (fal.Contains("TRFALSE"))
                                    //    {
                                    //        Oper.Add(f);
                                    //    }
                                    //}
                                    TR++;
                                    dataGridView3.Rows.Add(indice, objetoss, fuentess, "Q");
                                    indice++;

                                    for (int l = 0; l < Oper.Count; l++)
                                    {
                                        if (Convert.ToString(Oper[l]) == "Q")
                                        {
                                            Oper[l] = Oper.Count + 2;
                                        }
                                    }

                                }
                                else if (CICLO == "DESDE")
                                {
                                    Oper.Add(Oper.Count + 4);
                                    
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("TRUE");
                                    Oper.Add("Q");
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("FALSE");
                                    DatObjeto.Add("FINDESDE");
                                    DatFuente.Add("");
                                    
                                    Oper.Add("");

                                }
                                else if (CICLO == "HACER")
                                {
                                    Oper.Add(Oper.Count + 3);
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("TRUE");
                                    Oper.Add(Oper.Count + 3);
                                    DatObjeto.Add("TR" + TR);
                                    DatFuente.Add("FALSE");
                                }
                                 else
                                 {
                                     
                                         Oper.Add(inicioejecuta + 1);
                                         DatObjeto.Add("TR" + TR);
                                         DatFuente.Add("TRUE");
                                         Oper.Add(Oper.Count + 2);
                                         DatObjeto.Add("TR" + TR);
                                         DatFuente.Add("FALSE");
                                         DatObjeto.Add("FIN");
                                         DatFuente.Add("");
                                         Oper.Add("");

                                     
                                 }
                                dataGridView3.Rows.Clear();
                                dataGridView3.Refresh();
                                if (CICLO == "")
                                {


                                    DatObjeto.Add("ET");
                                    DatFuente.Add("TRTRUE");
                                    Oper.Add((DatObjeto.Count - 1) + 4);

                                    DatObjeto.Add("ET");

                                    Oper.Add((DatObjeto.Count - 1) + 2);

                                    DatFuente.Add("TRFALSE");
                                    DatObjeto.Add("FINSINCICLO");
                                    DatFuente.Add("");
                                    Oper.Add("");
                                }
                                else if (CICLO == "HACER")
                                {
                                    DatObjeto.Add("ET");
                                    DatFuente.Add("TRTRUE");
                                    Oper.Add((DatObjeto.Count - 1) + 4);

                                    DatObjeto.Add("ET");

                                    Oper.Add((DatObjeto.Count - 1) + 2);

                                    DatFuente.Add("TRFALSE");
                                    DatObjeto.Add("FIN");
                                    DatFuente.Add("");
                                    Oper.Add("");
                                }


                                CICLO = "";

                                //for (int l = 0; l < Oper.Count; l++)
                                //{
                                //    if (Convert.ToString(Oper[l]) == "Q")
                                //    {
                                //        for (int tr = 0; tr < DatObjeto.Count; tr++)
                                //        {
                                //            if (DatObjeto[tr]=="FIN")
                                //            {
                                //                Oper[l] = tr+2;
                                //            }
                                //        }
                                //    }
                                //}


                                



                                CadenaAuxiliar.Clear();
                                CadenaAuxiliar2.Clear();
                                cadena = "";
                                cadenaauxiliar = "";
                                cadenaoriginal = "";
                                cantidaddeoperadoresAND--;

                            }
                        }

                    }
                    //checo cada token si contiene un + - * / ^
                    else if (cadeoriginal.Contains('+') ||
                        cadeoriginal.Contains('-') ||
                        cadeoriginal.Contains('*') ||
                        cadeoriginal.Contains('/') ||
                        cadeoriginal.Contains('^')




                        )
                    {
                        int decimos = 1;
                        //Si con tienen lo agrego y sigo con los pasos

                        CadenaAuxiliar.Add(cadeoriginal);
                        string primero = "", segundo = "";
                        int esta = 0;
                        string cadenaaux2 = "";
                        CadenaAuxiliar2.Add(CadenaAuxiliar[CadenaAuxiliar.Count - 3]);
                        CadenaAuxiliar2.Add(CadenaAuxiliar[CadenaAuxiliar.Count - 2]);
                        CadenaAuxiliar2.Add(CadenaAuxiliar[CadenaAuxiliar.Count - 1]);
                        string detectarTE = "";

                        detectarTE = Convert.ToString(CadenaAuxiliar2[1]);
                        pasadaOPL = 1;






                        if (detectarTE.Contains("TE"))
                        {
                            AGREGARCONTEYTE();
                            del0al9++;
                            if (Convert.ToString(CadenaAuxiliar2[0]).Contains("TE"))
                            {
                                if (te <= 9)
                                {
                                    DatObjeto.Add(CadenaAuxiliar2[0]);
                                    DatFuente.Add(CadenaAuxiliar2[1]);
                                    Oper.Add(CadenaAuxiliar2[2]);
                                    
                                    
                                        
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                    CadenaAuxiliar2.RemoveRange(0, 3);


                                }
                                else
                                {
                                    DatObjeto.Add(CadenaAuxiliar2[0]);
                                    DatFuente.Add(CadenaAuxiliar2[1]);
                                    Oper.Add(CadenaAuxiliar2[2]);
                                    
                                    
                                       
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);

                                    CadenaAuxiliar2.RemoveRange(0, 3);

                                }
                            }
                            else if (del0al9 < 9)
                            {
                                AGREGARCONTEYTE();
                                if (te <= 9)
                                {
                                    TE.Add(te);
                                    DatObjeto.Add("TE0" + te);
                                    
                                    
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 3);
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                        CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                        CadenaAuxiliar.Add("TE0" + te);
                                    

                                }
                                else
                                {
                                    DatFuente.Add("TE" + te);
                                    CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 3);
                                    CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                    CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                    
                                        
                                        CadenaAuxiliar.Add("TE0" + te);
                                    


                                }

                                DatFuente.Add(CadenaAuxiliar2[0]);
                                Oper.Add("CAE$");
                                if (te <= 9)
                                {

                                    DatObjeto.Add("TE0" + te);
                                    DatFuente.Add(CadenaAuxiliar2[1]);
                                    te++; TE.Add("TE0" + te);
                                }
                                else
                                {
                                    DatObjeto.Add("TE" + te);
                                    DatFuente.Add("TE" + te);
                                    te++; TE.Add("TE0" + te);
                                }
                                

                                Oper.Add(CadenaAuxiliar2[2]);


                                CadenaAuxiliar2.RemoveRange(0, 3);
                                
                            }

                        }
                        else if (Convert.ToString( CadenaAuxiliar2[0]).Contains("TE"))
                        {

                            if (te <= 9)
                            {
                                DatObjeto.Add(CadenaAuxiliar2[0]);
                                DatFuente.Add(CadenaAuxiliar2[1]);
                                Oper.Add(CadenaAuxiliar2[2]);
                                te--;

                               
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 3);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                
                                    CadenaAuxiliar.Add("TE0" + te);
                                
                                te++;
                            }
                            else
                            {
                                DatObjeto.Add(CadenaAuxiliar2[0]);
                                DatFuente.Add(CadenaAuxiliar2[1]);
                                Oper.Add(CadenaAuxiliar2[2]);
                                
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 3);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                
                                    CadenaAuxiliar.Add("TE0" + te);
                                

                            }
                            CadenaAuxiliar2.RemoveRange(0, 3);
                        }
                        else
                        {


                           

                            string x = cadeoriginal;
                            if (te <= 9)
                            {
                                DatObjeto.Add("TE0" + te);
                                DatFuente.Add(CadenaAuxiliar2[0]);
                                Oper.Add("CAE$");
                                TE.Add("TE0" + te);

                                DatObjeto.Add("TE0" + te);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 3);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                
                                    CadenaAuxiliar.Add("TE0" + te);
                                

                            }
                            else
                            {
                                DatObjeto.Add("TE" + te);
                                DatFuente.Add(CadenaAuxiliar2[0]);
                                Oper.Add("CAE$");
                                TE.Add("TE0" + te);
                                DatObjeto.Add("TE" + te);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 3);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 2);
                                CadenaAuxiliar.RemoveAt(CadenaAuxiliar.Count - 1);
                                
                                    CadenaAuxiliar.Add("TE0" + te);
                                

                            }

                            DatFuente.Add(CadenaAuxiliar2[1]);
                            Oper.Add(CadenaAuxiliar2[2]);
                            CadenaAuxiliar2.RemoveRange(0, 3);
                            te++;

                        }


                    }


                    else if (cadeoriginal.Contains("CAE$"))
                    {
                        //MessageBox.Show("Fin de Cadena!");
                        int x = 0;

                        CadenaAuxiliar.Add(Convert.ToString(cadeoriginal));
                        DatObjeto.Add(CadenaAuxiliar[0]);
                        DatFuente.Add(CadenaAuxiliar[1]);
                        Oper.Add(CadenaAuxiliar[2]);



                    }
                    else if (CadenaOriginal.Count == 1)
                    {
                        if (te <= 9)
                        {
                            for (int qw = DatFuente.Count - 1; qw > 0; qw--)
                            {
                                if (Convert.ToString(Oper[qw]).Contains("OR"))
                                {
                                    ContenidoTE.Add(CadenaOriginal[0]);
                                    if (te < 9)
                                    {
                                        TE.Add("TE0" + te);
                                    }
                                    else
                                    {
                                        TE.Add("TE" + te);

                                    }
                                    DatObjeto.Insert(qw, "TE0" + te);
                                    DatFuente.Insert(qw, CadenaOriginal[0]);
                                    Oper.Insert(qw, "CAE$");
                                    te++;
                                    break;
                                }
                            }






                        }
                        else
                        {
                            DatObjeto.Add("TE" + te);
                            DatFuente.Add(CadenaOriginal[0]);
                            Oper.Add("CAE$");


                        }
                    }
                    else if ((cadeoriginal.Contains("OPL&") || cadeoriginal.Contains("OPL|")) && i == CadenaOriginal.Count - 1)
                    {
                        indice = 1;

                        for (int l = 0; l < Oper.Count; l++)
                        {
                            if (Convert.ToString(Oper[l]) == "Q")
                            {
                                Oper[l] = Oper.Count + 2;
                            }
                        }


                        dataGridView3.Rows.Clear();
                        dataGridView3.Refresh();
                        if (CICLO == "")
                        {
                            DatObjeto.Add("ET");
                            DatFuente.Add("TRTRUE");
                            Oper.Add((DatObjeto.Count - 1) + 3);
                            DatObjeto.Add("ET");
                            DatFuente.Add("TRFALSE");
                            Oper.Add((DatObjeto.Count - 1) + 2);
                            for (int er = 0; er < DatObjeto.Count; er++)
                            {
                                if (Oper[er] == "w" | Oper[er] == "trtrue")
                                {
                                    Oper[er] = DatObjeto.Count - 1;
                                }
                                else if (Oper[er] == "FALSEANDTOOR")
                                {
                                    Oper[er] = DatObjeto.Count;
                                }
                                else if (Oper[er] == "directoatrue")
                                {
                                    Oper[er] = DatObjeto.Count - 1;
                                }
                            }
                        }
                        else if (CICLO == "DESDE")
                        {
                            for (int l = 0; l < Oper.Count; l++)
                            {
                                if (Convert.ToString(Oper[l]) == "Q")
                                {
                                    Oper[l] = Oper.Count + 2;
                                }
                            }
                        }



                        DatObjeto.Add("FIN");
                        DatFuente.Add("");
                        Oper.Add("");
                        for (int bn = 0; bn < DatObjeto.Count; bn++)
                        {
                            dataGridView3.Rows.Add(indice, DatObjeto[bn], DatFuente[bn], Oper[bn]);
                            indice++;
                        }

                        break;

                    }

                    else
                        if (cadeoriginal.Contains("OPL&") || cadeoriginal.Contains("OPL|"))
                        {

                            if (otroopl == 1)
                            {
                                for (int er = 0; er < DatObjeto.Count; er++)
                                {
                                    if (Oper[er] == "w" && primeroopl != "&")
                                    {
                                        Oper[er] = DatObjeto.Count + 1;
                                        op = 1;
                                    }
                                    if (Oper[er] == "FALSEANDTOOR")
                                    {
                                        Oper[er] = DatObjeto.Count + 1;
                                        op++;
                                    }

                                }
                            }

                        }

               //si no lo agrego y sigo iterando
                        else
                        {
                            CadenaAuxiliar.Add(cadeoriginal);
                            string x = "";
                            for (int c = 0; c < CadenaAuxiliar.Count; c++)
                            {


                                x = Convert.ToString(CadenaAuxiliar[c]);



                            }
                        }


                }
                CadenaOriginal.Clear();
                CadenaAuxiliar.Clear();
                CadenaAuxiliar2.Clear();
                cadena = "";
                cadenaauxiliar = "";
                cadenaoriginal = "";
                pasada = 1;
                otroopl = 0;
                
                LinePorLineaAuxiliar.RemoveAt(s);
                LinePorLineaOriginal.RemoveAt(s);
                s--;
            }
            
            dataGridView3.Rows.Clear();
            dataGridView3.Refresh();
            indice = 1;
            //for (int l = 0; l < Oper.Count; l++)
            //{
            //    if (Convert.ToString(Oper[l]) == "Q")
            //    {
            //        for (int tr = 0; tr < DatObjeto.Count; tr++)
            //        {
            //            if (DatObjeto[tr] == "FIN")
            //            {
            //                Oper[l] = tr + 1;
            //            }
            //        }
            //    }
            //}
            //for (int bn = 0; bn < DatObjeto.Count; bn++)
            //{
            //    dataGridView3.Rows.Add(indice, DatObjeto[bn], DatFuente[bn], Oper[bn]);
            //    indice++;
            //}
        }
        private void AGREGARCONTEYTE()
        {
            for (int b = 0; b < CadenaAuxiliar2.Count - 1; b++)
            {
                cadaux2 = Convert.ToString(CadenaAuxiliar2[b]);
                for (int p = 0; p < ContenidoTE.Count; p++)
                {
                    contTE = Convert.ToString(ContenidoTE[p]);
                    if (cadaux2 == contTE)
                    {
                        esta = 1;
                    }
                }
                if (esta != 1)
                {
                    
                    ContenidoTE.Add(CadenaAuxiliar2[b]);
                    if (te < 9)
                    {
                        TE.Add("TE0" + te);
                        te++;
                    }
                    else
                    {
                        TE.Add("TE" + te);
                        te++;
                    }

                   


                        DatObjeto.Add(TE[TE.Count - 1]);
                        DatFuente.Add(ContenidoTE[ContenidoTE.Count - 1]);
                        string objetos = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
                        string fuentes = Convert.ToString(DatFuente[DatFuente.Count - 1]);

                        if (!(objetos.Contains("TE") && fuentes.Contains("TE")))
                        {

                            Oper.Add("CAE$");
                            dataGridView3.Rows.Add(indice, objetos, fuentes, Oper[Oper.Count - 1]);
                            indice++;
                        }
                        else
                        {
                            Oper.Add("CAE$");
                            dataGridView3.Rows.Add(indice, objetos, fuentes, Oper[Oper.Count - 1]);
                            indice++;

                        }

                    

                }
                esta = 0;
            }

            for (int qw = 0; qw < ContenidoTE.Count; qw++)
            {
                if (Convert.ToString(CadenaAuxiliar2[0]) == Convert.ToString(ContenidoTE[qw]))
                {
                    DatObjeto.Add(TE[qw]);
                }
                else if (Convert.ToString(CadenaAuxiliar2[1]) == Convert.ToString(ContenidoTE[qw]))
                {
                    DatFuente.Add(TE[qw]);
                }
            }

            string objt = Convert.ToString(DatObjeto[DatObjeto.Count - 1]);
            string fue = Convert.ToString(DatFuente[DatFuente.Count - 1]);
            if (objt.Contains("TE") && fue.Contains("TE"))
            {
                Oper.Add(CadenaAuxiliar2[2]);

                dataGridView3.Rows.Add(indice, objt, fue, Oper[Oper.Count - 1]);
                indice++;

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void richTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void barra_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void MenuAbrir_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void tripletas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
