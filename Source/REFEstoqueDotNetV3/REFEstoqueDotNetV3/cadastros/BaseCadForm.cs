using System;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using REFEstoqueDotNetV3.REF.componentes;
using REFEstoqueDotNetV3.exceptions;
using REFEstoqueDotNetV3.model;
using REFEstoqueDotNetV3.REF.forms;
using REFEstoqueDotNetV3.system;


namespace REFEstoqueDotNetV3.cadastros
{
    public class BaseCadForm : BaseForm
    {
        public BaseCadForm()
        {
            base.isEscClose = false;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDownForm);

            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;

            InitializeComponent();
            posicionarComponentes();
            atulizarForm();
        }

        #region sysDeclare
        private System.Windows.Forms.FlowLayoutPanel pnlInferior;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Panel pnlTopo;
        private System.Windows.Forms.Panel pnlNavegacao;
        private System.Windows.Forms.TextBox txtRecordCout;
        private System.Windows.Forms.Button btnUltimo;
        private System.Windows.Forms.Button btnAnterior;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnPrimeiro;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.Button btnFiltrar;
        #endregion

        //Colecao de beans consultados ou a inserir
        private ArrayList _beanDataSet = new ArrayList();
        private int _beanIndex = 0;
        private bool _isFirstFilter = true;

        //sera usado no momento do filtro para as pesquisas
        Hashtable _filterList = new Hashtable();
        //usado para controlar o status do Form
        private CadFormStatus _cadFormStatus = CadFormStatus.EXIBICAO;
        private REFPanelStatusRecord pnslStatus;

        //referencia ao forms Filho
        Control _container = null;


        protected void init(BaseModel find, Control container)
        {
            _container = container;
            setValidadores(container);
        }

        private void posicionarComponentes()
        {
            pnlNavegacao.Location = new Point((pnlTopo.Size.Width - pnlNavegacao.Size.Width) / 2, 0);
        }
        private void prepararFields(Control container)
        {
            if (container != null)
            {
                foreach (Control c in container.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        prepararFields(c);
                    }
                    else
                    {
                        if (c is REFTextBox)
                        {
                            REFTextBox t = (REFTextBox)c;
                            if (this.cadFormStatus == CadFormStatus.CONSULTA)
                            {
                                t.Text = "";
                                if (t.isFilterItem)
                                {
                                    t.Enabled = true;
                                    t.ReadOnly = false;
                                    t.BackColor = Color.LightYellow;
                                }
                                else
                                {
                                    t.Enabled = false;
                                    t.BackColor = Color.LightGray;
                                }
                                if (!_isFirstFilter)
                                {
                                    try
                                    {
                                        t.Text = _filterList[t.beanItemName].ToString();
                                    }
                                    catch (NullReferenceException e)
                                    {
                                        t.Text = "";
                                        throw e;
                                    }
                                }

                            }
                            else
                            {
                                t.tipo = t.tipo;
                                t.Text = "";
                            }
                        }
                    }
                }
            }
        }
        private void prepararIndex()
        {
            if (beanDataSet != null && beanDataSet.Count > 0)
            {
                txtRecordCout.Text = beanIndex + " de " + beanDataSet.Count;
            }
            else
            {
                beanIndex = 0;
                txtRecordCout.Text = "-------";
            }
        }

        private void salvarFiltros(Control container)
        {
            if (container != null)
            {
                foreach (Control c in container.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        salvarFiltros(c);
                    }
                    else
                    {
                        if (c is REFTextBox)
                        {
                            REFTextBox t = (REFTextBox)c;
                            if (t.isPK || t.isDataBaseItem)
                                if (t.beanItemName != "")
                                    _filterList.Add(t.beanItemName, t.Text);
                        }
                    }
                }
            }
        }

        private new void keyDownForm(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    this.fechar();
                    break;
                case Keys.F10:
                    if (btnSalvar.Enabled)
                        this.salvar();
                    break;
                case Keys.F8:
                    if (btnConsultar.Enabled)
                        this.consultar();
                    break;
                case Keys.F7:
                    if (btnFiltrar.Enabled)
                        this.filtrar();
                    break;
                case Keys.F6:
                    if (btnNovo.Enabled)
                        this.novo();
                    break;
                case Keys.F3:
                    if (btnExcluir.Enabled)
                        this.excluir();
                    break;
            }
        }

        private void fechar()
        {
            if (this.cadFormStatus == CadFormStatus.EXIBICAO)
            {
                this.Close();
            }
            else
            {
                //possibilidade para adicionar outras funcionalidades
                this.cancelarAlteracoes();
            }
        }
        protected void iniciarFiltro()
        {
            btnExcluir.Enabled = false;
            btnNovo.Enabled = false;
            btnFiltrar.Enabled = _isFirstFilter;
            btnConsultar.Enabled = true;
            btnSalvar.Enabled = false;
            this.cadFormStatus = CadFormStatus.CONSULTA;
            beanDataSet.Clear();
            beanIndex = 0;
            atulizarForm();
            _isFirstFilter = false;
        }
        protected void finalizarConsulta()
        {
            btnExcluir.Enabled = true;
            btnNovo.Enabled = true;
            btnFiltrar.Enabled = true;
            btnConsultar.Enabled = false;
            btnSalvar.Enabled = true;
            this.cadFormStatus = CadFormStatus.EXIBICAO;
            atulizarForm();
            _isFirstFilter = true;
            _filterList.Clear();
            salvarFiltros(_container);
            if (beanDataSet.Count > 1)
            {
                firstRecord();
            }
        }
        private void atulizarForm()
        {
            prepararIndex();
            prepararFields(_container);
        }
        protected void incluirRegistro(BaseModel obj)
        {
            try
            {
                this.validarRegistro(_container);
                obj.dataStatus = DataStatus.NOVO;
                if (this.beanDataSet == null)
                {
                    this.beanDataSet = new ArrayList();
                }
                this.beanDataSet.Add(obj);
                this.cadFormStatus = CadFormStatus.ALTERACAO;
                this.lastRecord();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        protected void excluirRegistro()
        {
            try
            {
                if (beanDataSet != null && beanDataSet.Count > 0)
                {
                    if (beanIndex > 0)
                    {
                        BaseModel obj = ((BaseModel)beanDataSet[beanIndex - 1]);

                        if (obj.dataStatus == DataStatus.NOVO)
                        {
                            beanDataSet.RemoveAt(beanIndex - 1);
                            beanIndex -= 1;
                            goRecord(beanIndex);
                        }
                        else
                        {
                            obj.dataStatus = DataStatus.EXCLUIDO;
                            pnslStatus.dataStatus = obj.dataStatus;
                        }
                        cadFormStatus = CadFormStatus.ALTERACAO;
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #region navegaor
        private void goRecord(int index)
        {
            try
            {
                if (beanDataSet != null && beanDataSet.Count > 0)
                {
                    if (beanIndex > 0)
                    {
                        setObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        prepararIndex();
                    }
                    else
                    {
                        firstRecord();
                    }
                }
                else
                {
                    cancelarAlteracoes();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void firstRecord()
        {
            try
            {
                if (beanDataSet != null && beanDataSet.Count > 0)
                {
                    if (beanIndex != 1)
                    {
                        //salvar alteracoes
                        if (beanIndex > 0)
                        {
                            this.validarRegistro(_container);
                            beanDataSet[beanIndex - 1] = getObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        }
                        //navegar
                        beanIndex = 1;
                        setObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        prepararIndex();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void lastRecord()
        {
            try
            {
                if (beanDataSet != null && beanDataSet.Count > 0)
                {
                    if (beanIndex < beanDataSet.Count)
                    {
                        //salvar alteracoes
                        if (beanIndex > 0)
                        {
                            this.validarRegistro(_container);
                            beanDataSet[beanIndex - 1] = getObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        }
                        //navegar
                        beanIndex = beanDataSet.Count;
                        setObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        prepararIndex();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void nextRecord()
        {
            try
            {
                if (beanDataSet != null && beanDataSet.Count > 0)
                {
                    if (beanIndex < beanDataSet.Count)
                    {
                        //salvar alteracoes
                        if (beanIndex > 0)
                        {
                            this.validarRegistro(_container);
                            beanDataSet[beanIndex - 1] = getObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        }
                        //navegar
                        beanIndex += 1;
                        setObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        prepararIndex();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        private void previousRecord()
        {
            try
            {
                if (beanDataSet != null && beanDataSet.Count > 0)
                {
                    if (beanIndex > 1)
                    {
                        //salvar alteracoes
                        if (beanIndex > 0)
                        {
                            this.validarRegistro(_container);
                            beanDataSet[beanIndex - 1] = getObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        }
                        //navegar
                        beanIndex -= 1;
                        setObgectValues((BaseModel)beanDataSet[beanIndex - 1]);
                        prepararIndex();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        protected virtual void setObgectValues(BaseModel beanObj)
        {
            this.pnslStatus.dataStatus = beanObj.dataStatus;
        }

        protected virtual object getObgectValues(BaseModel beanObj)
        {
            throw new NotImplementedException();
        }

        private void btnPrimeiro_Click(object sender, EventArgs e)
        {
            this.firstRecord();
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.previousRecord();
        }

        private void btnProximo_Click(object sender, EventArgs e)
        {
            this.nextRecord();
        }

        private void btnUltimo_Click(object sender, EventArgs e)
        {
            this.lastRecord();
        }
        #endregion

        #region validador
        private void validador(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (beanDataSet != null && beanDataSet.Count > 0)
            {
                if (((sender as REFTextBox).isAltered) &&
                    (beanDataSet[beanIndex - 1] as BaseModel).dataStatus == DataStatus.EXIBICAO)
                {
                    (beanDataSet[beanIndex - 1] as BaseModel).dataStatus = DataStatus.ALTERADO;
                    pnslStatus.dataStatus = DataStatus.ALTERADO;
                    cadFormStatus = CadFormStatus.ALTERACAO;
                }
                if (((sender as REFTextBox).tipo == TipoTextBox.REQUIRED)
                    && ((sender as REFTextBox).Text == ""))
                {
                    e.Cancel = true;
                    throw new ValueRequiredException("Campo de preenchimento obrigatório.");
                }
            }
        }
        private void setValidadores(Control container)
        {
            if (container != null)
            {
                foreach (Control c in container.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        setValidadores(c);
                    }
                    else
                    {
                        if (c is REFTextBox)
                        {
                            REFTextBox t = (REFTextBox)c;
                            if (t.isDataBaseItem)
                            {
                                t.Validating += new System.ComponentModel.CancelEventHandler(this.validador);
                            }
                        }
                    }
                }
            }
        }
        private void validarRegistro(Control container)
        {
            if (container != null && beanDataSet != null && beanDataSet.Count > 0)
            {
                foreach (Control c in container.Controls)
                {
                    if (c.Controls.Count > 0)
                    {
                        setValidadores(c);
                    }
                    else
                    {
                        if (c is REFTextBox)
                        {
                            REFTextBox t = (REFTextBox)c;
                            if (t.isDataBaseItem && t.tipo == TipoTextBox.REQUIRED
                                && t.Text == "")
                            {
                                t.Select();
                                throw new ValueRequiredException("Campo de preenchimento obrigatório.");
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region uteis
        protected int getNumberFromText(REFTextBox t)
        {
            try
            {
                return (t.Text != null && t.Text != "") ? Convert.ToInt32(t.Text) : 0;
            }
            catch (FormatException e)
            {
                throw new InvalidPropertyValueException("Valor " + t.Text + " não é um número válido", e);
            }
        }
        #endregion

        #region properties

        protected int beanIndex
        {
            set
            {
                if (value >= 0)
                {
                    _beanIndex = value;
                }
                else
                {
                    _beanIndex = 0;
                }
            }
            get { return _beanIndex; }
        }

        public ArrayList beanDataSet
        {
            set
            {
                _beanDataSet = value;
                foreach (BaseModel o in _beanDataSet)
                {
                    o.dataStatus = DataStatus.EXIBICAO;
                }
            }
            get { return _beanDataSet; }
        }
        //public int beanIndex
        //{
        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new InvalidPropertyValue("Index inválido!. Informe um valor maior que 0.");
        //        }
        //        else if ((beanDataSet == null ? 0 : beanDataSet.Count) == 0)
        //        {
        //            throw new InvalidPropertyValue("Index inválido!. Não existem registros consultados.");
        //        }
        //        else if (value > beanDataSet.Count)
        //        {
        //            throw new InvalidPropertyValue("Index inválido!. Informe um valor entre 1 e" + beanDataSet.Count + ".");
        //        }
        //        else
        //        {
        //            _beanIndex = value;
        //        }
        //    }
        //    get { return _beanIndex; }
        //}

        public CadFormStatus cadFormStatus
        {
            get { return _cadFormStatus; }
            set { _cadFormStatus = value; }
        }
        #endregion

        #region InitializeComponent
        private void InitializeComponent()
        {
            this.pnlTopo = new System.Windows.Forms.Panel();
            this.pnlNavegacao = new System.Windows.Forms.Panel();
            this.txtRecordCout = new System.Windows.Forms.TextBox();
            this.btnUltimo = new System.Windows.Forms.Button();
            this.btnAnterior = new System.Windows.Forms.Button();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnPrimeiro = new System.Windows.Forms.Button();
            this.pnlInferior = new System.Windows.Forms.FlowLayoutPanel();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.pnslStatus = new REFEstoqueDotNetV3.REF.componentes.REFPanelStatusRecord();
            this.pnlTopo.SuspendLayout();
            this.pnlNavegacao.SuspendLayout();
            this.pnlInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopo
            // 
            this.pnlTopo.BackgroundImage = global::REFEstoqueDotNetV3.Properties.Resources.degrade_cinza;
            this.pnlTopo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlTopo.Controls.Add(this.pnlNavegacao);
            this.pnlTopo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopo.Location = new System.Drawing.Point(0, 0);
            this.pnlTopo.Name = "pnlTopo";
            this.pnlTopo.Size = new System.Drawing.Size(514, 25);
            this.pnlTopo.TabIndex = 1;
            // 
            // pnlNavegacao
            // 
            this.pnlNavegacao.BackColor = System.Drawing.Color.Transparent;
            this.pnlNavegacao.Controls.Add(this.txtRecordCout);
            this.pnlNavegacao.Controls.Add(this.btnUltimo);
            this.pnlNavegacao.Controls.Add(this.btnAnterior);
            this.pnlNavegacao.Controls.Add(this.btnProximo);
            this.pnlNavegacao.Controls.Add(this.btnPrimeiro);
            this.pnlNavegacao.Location = new System.Drawing.Point(165, 0);
            this.pnlNavegacao.Name = "pnlNavegacao";
            this.pnlNavegacao.Size = new System.Drawing.Size(298, 25);
            this.pnlNavegacao.TabIndex = 5;
            // 
            // txtRecordCout
            // 
            this.txtRecordCout.BackColor = System.Drawing.SystemColors.Control;
            this.txtRecordCout.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtRecordCout.Location = new System.Drawing.Point(91, 3);
            this.txtRecordCout.Name = "txtRecordCout";
            this.txtRecordCout.ReadOnly = true;
            this.txtRecordCout.Size = new System.Drawing.Size(116, 20);
            this.txtRecordCout.TabIndex = 9;
            this.txtRecordCout.Text = "XXX DE YYY";
            this.txtRecordCout.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUltimo
            // 
            this.btnUltimo.Image = global::REFEstoqueDotNetV3.Properties.Resources.icoUltimo;
            this.btnUltimo.Location = new System.Drawing.Point(253, 1);
            this.btnUltimo.Name = "btnUltimo";
            this.btnUltimo.Size = new System.Drawing.Size(40, 23);
            this.btnUltimo.TabIndex = 8;
            this.btnUltimo.UseVisualStyleBackColor = true;
            this.btnUltimo.Click += new System.EventHandler(this.btnUltimo_Click);
            // 
            // btnAnterior
            // 
            this.btnAnterior.Image = global::REFEstoqueDotNetV3.Properties.Resources.icoAnterior;
            this.btnAnterior.Location = new System.Drawing.Point(48, 1);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new System.Drawing.Size(40, 23);
            this.btnAnterior.TabIndex = 7;
            this.btnAnterior.UseVisualStyleBackColor = true;
            this.btnAnterior.Click += new System.EventHandler(this.btnAnterior_Click);
            // 
            // btnProximo
            // 
            this.btnProximo.Image = global::REFEstoqueDotNetV3.Properties.Resources.icoProximo;
            this.btnProximo.Location = new System.Drawing.Point(210, 1);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(40, 23);
            this.btnProximo.TabIndex = 6;
            this.btnProximo.UseVisualStyleBackColor = true;
            this.btnProximo.Click += new System.EventHandler(this.btnProximo_Click);
            // 
            // btnPrimeiro
            // 
            this.btnPrimeiro.Image = global::REFEstoqueDotNetV3.Properties.Resources.icoPrimeiro;
            this.btnPrimeiro.Location = new System.Drawing.Point(5, 1);
            this.btnPrimeiro.Name = "btnPrimeiro";
            this.btnPrimeiro.Size = new System.Drawing.Size(40, 23);
            this.btnPrimeiro.TabIndex = 5;
            this.btnPrimeiro.UseVisualStyleBackColor = true;
            this.btnPrimeiro.Click += new System.EventHandler(this.btnPrimeiro_Click);
            // 
            // pnlInferior
            // 
            this.pnlInferior.BackgroundImage = global::REFEstoqueDotNetV3.Properties.Resources.degrade_cinza;
            this.pnlInferior.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlInferior.Controls.Add(this.btnFechar);
            this.pnlInferior.Controls.Add(this.btnSalvar);
            this.pnlInferior.Controls.Add(this.btnConsultar);
            this.pnlInferior.Controls.Add(this.btnFiltrar);
            this.pnlInferior.Controls.Add(this.btnNovo);
            this.pnlInferior.Controls.Add(this.btnExcluir);
            this.pnlInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlInferior.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pnlInferior.Location = new System.Drawing.Point(0, 299);
            this.pnlInferior.Name = "pnlInferior";
            this.pnlInferior.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.pnlInferior.Size = new System.Drawing.Size(514, 50);
            this.pnlInferior.TabIndex = 0;
            // 
            // btnFechar
            // 
            this.btnFechar.Image = global::REFEstoqueDotNetV3.Properties.Resources.fechar;
            this.btnFechar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFechar.Location = new System.Drawing.Point(426, 3);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 45);
            this.btnFechar.TabIndex = 0;
            this.btnFechar.Text = "Fechar (Esc)";
            this.btnFechar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Image = global::REFEstoqueDotNetV3.Properties.Resources.icon_includ;
            this.btnSalvar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSalvar.Location = new System.Drawing.Point(345, 3);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 45);
            this.btnSalvar.TabIndex = 1;
            this.btnSalvar.Text = "Salvar (F10)";
            this.btnSalvar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Image = global::REFEstoqueDotNetV3.Properties.Resources.consultar;
            this.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnConsultar.Location = new System.Drawing.Point(259, 3);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(80, 45);
            this.btnConsultar.TabIndex = 4;
            this.btnConsultar.Text = "Consultar (F8)";
            this.btnConsultar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Image = global::REFEstoqueDotNetV3.Properties.Resources.filtrar;
            this.btnFiltrar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFiltrar.Location = new System.Drawing.Point(178, 3);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(75, 45);
            this.btnFiltrar.TabIndex = 5;
            this.btnFiltrar.Text = "Filtrar (F7)";
            this.btnFiltrar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnNovo
            // 
            this.btnNovo.Image = global::REFEstoqueDotNetV3.Properties.Resources.novo;
            this.btnNovo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnNovo.Location = new System.Drawing.Point(97, 3);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(75, 45);
            this.btnNovo.TabIndex = 2;
            this.btnNovo.Text = "Novo (F6)";
            this.btnNovo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Image = global::REFEstoqueDotNetV3.Properties.Resources.excluir;
            this.btnExcluir.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExcluir.Location = new System.Drawing.Point(16, 3);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(75, 45);
            this.btnExcluir.TabIndex = 3;
            this.btnExcluir.Text = "Excluir (F3)";
            this.btnExcluir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // pnslStatus
            // 
            this.pnslStatus.BackColor = System.Drawing.SystemColors.Control;
            this.pnslStatus.dataStatus = REFEstoqueDotNetV3.system.DataStatus.EXIBICAO;
            this.pnslStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnslStatus.Location = new System.Drawing.Point(0, 284);
            this.pnslStatus.Name = "pnslStatus";
            this.pnslStatus.Size = new System.Drawing.Size(514, 15);
            this.pnslStatus.TabIndex = 2;
            // 
            // BaseCadForm
            // 
            this.ClientSize = new System.Drawing.Size(514, 349);
            this.Controls.Add(this.pnslStatus);
            this.Controls.Add(this.pnlTopo);
            this.Controls.Add(this.pnlInferior);
            this.Name = "BaseCadForm";
            this.pnlTopo.ResumeLayout(false);
            this.pnlNavegacao.ResumeLayout(false);
            this.pnlNavegacao.PerformLayout();
            this.pnlInferior.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        #region SemiAbstratos
        //Cancela as alteracoes e volta o forms ao seu status inicial
        protected virtual void cancelarAlteracoes()
        {
            if (this.cadFormStatus != CadFormStatus.ALTERACAO ||
                beanDataSet == null ||
                beanDataSet.Count == 0 ||
                MessageBox.Show("Cancelar as alterações?", "Cancelar?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnExcluir.Enabled = true;
                btnNovo.Enabled = true;
                btnFiltrar.Enabled = true;
                btnConsultar.Enabled = false;
                btnSalvar.Enabled = true;
                this.cadFormStatus = CadFormStatus.EXIBICAO;
                this.pnslStatus.dataStatus = DataStatus.EXIBICAO;
                beanDataSet = new ArrayList();
                _isFirstFilter = true;
                atulizarForm();
            }
        }
        protected virtual void salvar()
        {
            MessageBox.Show("Salvar");
        }
        protected virtual void consultar()
        {
            finalizarConsulta();
        }
        protected virtual void filtrar()
        {
            iniciarFiltro();
        }
        protected virtual void novo()
        {
            MessageBox.Show("novo");
        }
        protected virtual void excluir()
        {
            excluirRegistro();
        }
        protected virtual void refiltro()
        {
            MessageBox.Show("refiltro");
        }
        #endregion

        #region botoes_inferiores
        private void btnExcluir_Click(object sender, System.EventArgs e)
        {
            this.excluir();
        }

        private void btnNovo_Click(object sender, System.EventArgs e)
        {
            this.novo();
        }

        private void btnFiltrar_Click(object sender, System.EventArgs e)
        {
            this.filtrar();
        }

        private void btnConsultar_Click(object sender, System.EventArgs e)
        {
            this.consultar();
        }

        private void btnSalvar_Click(object sender, System.EventArgs e)
        {
            this.salvar();
        }

        private void btnFechar_Click(object sender, System.EventArgs e)
        {
            this.fechar();
        }
        #endregion

    }
}

/* EXEMPLO REFLEXAO
 Type t = objFind.GetType();
            foreach (PropertyInfo p in t.GetProperties())
            {
                MessageBox.Show(p.Name + " = " + p.PropertyType);

                MessageBox.Show(p.GetValue(objFind, null).ToString());

                if (p.Name == "descr")
                    p.SetValue(objFind, "1", null);
            }
            txtDescr.Text = ((GrupoPessoa)objFind).descr;
 */