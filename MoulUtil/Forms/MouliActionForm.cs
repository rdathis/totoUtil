/*
 * Crée par SharpDevelop.
 * Utilisateur: Renaud
 * Date: 02/09/2016
 * Heure: 16:23:52
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using MoulUtil.Forms.utils;
using cmdUtils;
using cmdUtils.Objets;
using cmdUtils.Objets.utils;

namespace MoulUtil
{
	/// <summary>
	/// Form to pilot the work
	/// </summary>
	public partial class MouliActionForm : Form
	{
		private List<MeoServeur> serveurs = null;
		private List<MeoInstance> instances = null;
		private MouliJob job = null;
		private ConfigDto configDto;
		private String magId = null;
		private MouliUtil mouliUtil = null;
		private MouliUtilOptions options = null;
		private MouliActionUtil mouliActionUtil;
		private RichTextBoxUtil richTextBoxUtil=new RichTextBoxUtil();
		// disable FieldCanBeMadeReadOnly.Local
		private log4net.ILog LOGGER=null;
		private ToolTipUtil toolTipUtil=new ToolTipUtil();
		//
		//just for timer + bgworker
		private String progressBoxText=null;
		private String toolStripStatusLabelText=null;
		private int toolStripProgressBarValue=-1;
		private Boolean finalFlag=false;
		private Boolean installBtnEnabled=false;
		private Boolean finalUploadFlag=false;

		public MouliActionForm(MouliUtilOptions options, ConfigDto configDto, log4net.ILog  LOGGER, string path)
		{
			InitializeComponent();
			this.options = options;
			setConfigDto(configDto);
			setServeurs(configDto.getServeurs());
			setInstances(configDto.getInstances());
			setPath(path);
			setMagId(options.getMagId());
			setMagasinIrris(options.getNumeroMagasinIrris());
			this.LOGGER=LOGGER;
			mouliUtil= new MouliUtil(LOGGER);
			prepare();
			MeoInstance instance = MeoInstance.findInstanceByInstanceName(configDto.getInstances(), options.getInstanceName());
			if (instance != null && instance.getServeur() != null) {
				MeoServeur serveur = MeoServeur.findServeurByName(configDto.getServeurs(), instance.getServeur());
				if (serveur != null) {
					pscpLink.Tag = serveur;
					cibleLabel.Text = options.getInstanceName() + " (" + serveur.getNom() + " " + serveur.getAdresse() + ")";
					cibleLabel.BackColor = Color.AntiqueWhite;
					cibleLabel.ForeColor = Color.Red;
					puttyLink.Tag = serveur;
					puttyLink.Visible = true;
				}
			}
			//fait l'analyse
			AnalyseLabelClick(null, null);
		}
		
		void populateToolTips()
		{
			toolTipUtil.add(this.purgeClientChkBox, "Demander un import des données CLIENTS sans extensions (dossiers de moins de 10 ans)");
			toolTipUtil.add(this.purgeStockChkBox, "Demander un import des données STOCK sans extensions (stock nul ou neg. limité à 1 an plein)");
			toolTipUtil.add(this.irrisMagTBox, "Numero de mag dans irris (de mag01 à  mag99 ?)");
			toolTipUtil.add(this.path, "chemin de la moulinette");
			toolTipUtil.add(this.dateTimePicker, "Choix de la date d'installation des données(à 8h00 du matin)");
			toolTipUtil.add(this.magIdTextBox, "magId ");

			toolTipUtil.add(this.analyseLabel, "Analyser les données pour calculer les options");

			toolTipUtil.add(this.optionCCheckBox, "Inclure les données CLIENT dans le traitement");
			toolTipUtil.add(this.optionSCheckBox, "Inclure les données STOCK dans le traitement");
			toolTipUtil.add(this.optionJCheckBox, "Inclure les documents du mag01/Joint/.. dans le traitement (pdf, jpg, png)");
			toolTipUtil.add(this.optionDCheckBox, "Inclure les documents du ord01/ et doc01/ (irris)");
			toolTipUtil.add(this.optionC1CheckBox, "ANNULER une moulinette CLIENT");
			toolTipUtil.add(this.optionS1CheckBox, "ANNULER une moulinette STOCK");

			toolTipUtil.add(this.propositionMailsListBox, "Choix d'emails possibles");
			toolTipUtil.add(this.puttyLink, "lancer un putty vers ce serveur");
			toolTipUtil.add(this.pscpLink, "copier les données avec pscp (préférer '[upload]' ");

			toolTipUtil.add(this.emailTextbox, "Email qui recevra les notifications de début et de fin du des traitements");
			toolTipUtil.add(this.progressTextBox, "progression ");

			toolTipUtil.add(this.visuJobLabel, "Afficher le contenu du fichier 'job' (planification) ");
			toolTipUtil.add(this.visuScriptLabel, "afficher le contenu du fichier 'script' (exécution du traitement) ");

			toolTipUtil.add(this.goButton, "Lancer la création de l'archive");
			toolTipUtil.add(this.uploadButton, "Uploader l'archive vers le serveur cible");
			toolTipUtil.add(this.installBtn, "Installer le job sur le serveur cible (à la date paramétrée plus haut)");
			toolTipUtil.add(this.exitButton, "Fermer la fenêtre");
		}
		
		void prepareTimer()
		{
			formTimer.Interval=500;
			formTimer.Tick += new EventHandler(TimerEventProcessor);
			formTimer.Start();
		}
		
		// disable once ParameterHidesMember
		void setConfigDto(ConfigDto configDto)
		{
			this.configDto = configDto;
		}

		public void setServeurs(List<MeoServeur> serveurs)
		{
			this.serveurs = serveurs;
		}

		void setMagasinIrris(string str)
		{
			irrisMagTBox.Text = str;
		}

		public void setInstances(List<MeoInstance> instances)
		{
			this.instances = instances;
		}
		public void prepare()
		{
			puttyLink.Visible = false;
			pscpLink.Visible = false;
			dateTimePicker.Value = mouliUtil.calculeNextPlannedJob();
			prepareTimer();
			populateToolTips();
			activeExtension(purgeClientChkBox, options.getExtensionClient());
			activeExtension(purgeStockChkBox, options.getExtensionStock());
			installBtn.Enabled = false;
			progressTextBox.Visible = false;
			emailTextbox.Text = configDto.getDefaultEmail();
			mouliActionUtil = new MouliActionUtil(this, configDto, LOGGER, mouliUtil);
			String propositions = configDto.getConfigParamByName(ConfigParam.ParamNamesType.emails).Value;
			if(propositions!=null) {
				propositionMailsListBox.Items.Clear();
				String [] tablo=propositions.Split(',');
				propositionMailsListBox.Items.Add(emailTextbox.Text);
				if(tablo!=null) {
					for(int i=0;i<tablo.Length;i++) {
						propositionMailsListBox.Items.Add(tablo[i]);
					}
				}
			}
		}

		void activeExtension(CheckBox chkBox, MoulinettePurgeOptionTypes moulinettePurgeOptionTypes)
		{
			Boolean value = true;
			if (MoulinettePurgeOptionTypes.CLIENT_POSSEDE_EXTENSION == moulinettePurgeOptionTypes) {
				value = false;
			}
			chkBox.Enabled = value;
			chkBox.Checked = value;
			
			//mis en suspens, suite deux retards extensions
			chkBox.Checked = false;
			
		}
		
		// disable once ParameterHidesMember
		void analyseJob(MouliJob job)
		{
			if (job != null) {
				MouliStatRecap recap = job.getStatRecap();
				if (recap != null) {
					//[0]client [1]stock [2]joint [3]ord01
					optionCCheckBox.Checked = (recap.mag01ClientTotal > 0); //ycli
					optionSCheckBox.Checked = (recap.mag01StockTotal > 1); //ysto
					optionJCheckBox.Checked = (recap.jointDocsTotal > 0);
					optionDCheckBox.Checked = ((recap.ord01DocsTotal > 0) || (recap.doc01DocsTotal > 0));
				}
			}
		}
		void completeOptions()
		{
			configDto.setDefaultEmail(emailTextbox.Text);
			options = updateMouliUtilOption(MeoInstance.findInstanceByInstanceName(configDto.getInstances(), options.getInstanceName()));
		}

		void GoButtonClick(object sender, EventArgs e)
		{
			goButton.Enabled = false;
			uploadButton.Enabled = false;
			progressTextBox.Visible = true;
			progressTextBox.Enabled = false;
			toolStripStatusLabelText = "doing archive";
			try {
				completeOptions();
				CreateArchiveBackgroundWorker worker = CreateArchiveBackgroundWorker.createWorker();
				worker.prepare(job, mouliActionUtil);
				
				MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = name => {
					toolStripStatusLabelText = name;
					try {
						progressBoxText = " debut";
						toolStripProgressBarValue = 0;
					} catch (Exception ex) {
						LOGGER.Error("still exception here ..." + ex.Message);
					}
				};
				MouliProgressWorker.ProgressWorkerCallBack progressWorkerCallBack = value => {
					if (value <= 100) {
						toolStripProgressBarValue = value;//bug
					}
					toolStripStatusLabelText = "progression moulinette : " + (value) + "%  - x / " + worker.getNbOperation();
					progressBoxText = toolStripStatusLabelText;
				};
				MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
					toolStripStatusLabelText = "fini";
					toolStripProgressBarValue = 0;
					finalFlag=true;
				};
				//
				worker.setStartWorkerCallBack(startWorkerCallBack);
				worker.setProgressWorkerCallBack(progressWorkerCallBack);
				worker.setEndWorkerCallBack(endWorkerCallBack);
				//
				job.setBackgroundWorker(worker);
				worker.RunWorkerAsync();

			} catch (Exception ex) {
				MessageBox.Show(" Exception : " + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
			}
			goButton.Enabled = true;
		}

		public void updateProgression(int progression)
		{
			//progressBar1.Value=progression;
			// progressBar1.Refresh();
			toolStripProgressBarValue = progression;
		}
		public void setPath(string sourceMoulinette)
		{
			pathLabel.Text = sourceMoulinette;
			pathTextBox.Text = sourceMoulinette;
			pathTextBox.Enabled = false;
		}
		void ExitButtonClick(object sender, EventArgs e)
		{
			Hide();
		}
		
		void PuttyLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CmdUtil util = new CmdUtil();
			LinkLabel label = (LinkLabel)sender;
			if (label.Tag != null) {
				MeoServeur server = (MeoServeur)label.Tag;
				String args = util.buildPuttyArgs(server);
				util.executeCommande(MouliConfig.puttyPath, args);
			}
		}
		void PscpLinkLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (job != null) {
				CmdUtil util = new CmdUtil();
				LinkLabel label = (LinkLabel)sender;
				if (label.Tag != null) {
					MeoServeur server = (MeoServeur)label.Tag;
					String args = util.buildPscpArgs(server, job, configDto);
					util.executeCommande(MouliConfig.pscpPath, args);
				}
			}
		}
		void PuttyLinkClick(object sender, EventArgs e)
		{
			//TODO:check if usefull
		}

		private void calculateLots(MouliUtilOptions mouliUtilOptions)
		{
			// purges
			mouliUtilOptions.doAnnulationStock = optionS1CheckBox.Checked;
			mouliUtilOptions.doAnnulationClient = optionC1CheckBox.Checked;
			//
			mouliUtilOptions.doStock = optionSCheckBox.Checked;
			mouliUtilOptions.doClient = optionCCheckBox.Checked;
			mouliUtilOptions.doDoc01 = optionDCheckBox.Checked;
			mouliUtilOptions.doJoint = optionJCheckBox.Checked;
		}
		MouliUtilOptions updateMouliUtilOption(MeoInstance instance)
		{
			options.setInstanceCommande(instance.getMeocli());
			options.setInstanceName(instance.getNom());
			
			options.setIsJoint(false);
			options.setDefaultEmail(configDto.getDefaultEmail());
			
			calculateLots(options); //todo:calculer
			options.setDateJob(dateTimePicker.Value);
			options.setNumeroMagasinIrris(irrisMagTBox.Text);
			options.setMagId(magId);
			
			options.setExtensionClient(calculExtension(purgeClientChkBox));
			options.setExtensionStock(calculExtension(purgeStockChkBox));
			return options;
		}

		MoulinettePurgeOptionTypes calculExtension(CheckBox checkBox)
		{
			if (checkBox.Enabled) {
				if (checkBox.Checked) {
					return MoulinettePurgeOptionTypes.PURGE_DEMANDEE;
				} else {
					return MoulinettePurgeOptionTypes.PURGE_REFUSEE;
				}
				
			} else {
				return MoulinettePurgeOptionTypes.CLIENT_POSSEDE_EXTENSION;
			}
			
		}
		void CmdLabelClick(object sender, System.EventArgs e)
		{
			CmdUtil util = new CmdUtil();
			util.launchWindowsCmd();
		}

		
		void UploadButtonClick(object sender, EventArgs e)
		{
			if (job != null) {
				toolStripStatusLabel1.Text = "uploading archive...";
				CmdUtil util = new CmdUtil();
				LinkLabel label = pscpLink;
				if (label.Tag != null) {
					MeoServeur server = (MeoServeur)label.Tag;
					SshUtil sshUtil = new SshUtil();
					try {
						UploadArchiveBackgroundWorker worker = new UploadArchiveBackgroundWorker();
						String targetPath = server.getTranspo();
						worker.prepare(server, targetPath, job.getArchiveName());
						
						MouliProgressWorker.StartWorkerCallBack startWorkerCallBack = name => {
							this.toolStripStatusLabelText=name;
							try {
								progressBoxText=" debut";
								toolStripProgressBarValue = 0;
							} catch (Exception ex) {
								LOGGER.Error("still exception here ..." + ex.Message);
								progressBoxText = ex.Message;
							}
						};
						MouliProgressWorker.ProgressWorkerCallBack progressWorkerCallBack = value => {
							if (value <= 100) {
								toolStripProgressBarValue = value;//bug
							}
							toolStripStatusLabelText= "progression upload : " + (value) + "%  - x / " + worker.getNbOperation();
							progressBoxText = toolStripStatusLabelText;
						};
						MouliProgressWorker.EndWorkerCallBack endWorkerCallBack = value => {
							finalUploadFlag=true;

							try {
								String serverTargetPath = server.getTranspo();
								sshUtil.unzipArchive(server, serverTargetPath, job);
								
								
								
								CmdUtil cmdUtil = new CmdUtil();
								
								String cmd = mouliUtil.getUnzipCmd(server, serverTargetPath, job);
								String commandeFile = job.getOriginalDir()+"/"+ job.getMoulinettePath() + "install.file";
								mouliUtil.writeInstallMoulinetteFile(cmd, commandeFile);
								this.toolStripStatusLabelText= "finished";
								installBtnEnabled=true;
							} catch (Exception ex) {
								progressBoxText = "Exception : " + ex.Message;
								LOGGER.Error(ex);
							}
						};
						//
						worker.setStartWorkerCallBack(startWorkerCallBack);
						worker.setProgressWorkerCallBack(progressWorkerCallBack);
						worker.setEndWorkerCallBack(endWorkerCallBack);
						//
						worker.RunWorkerAsync();
					} catch (Exception ex) {
						LOGGER.Error(ex);
						MessageBox.Show("Erreur envoi data : " + ex.Message + "\n" + ex.Source + "\n" + ex.StackTrace);
					}
				}
			}
		}

		// disable once ParameterHidesMember
		void setMagId(string magId)
		{
			this.magId = magId;
			magIdTextBox.Text = magId;
			magIdTextBox.Enabled = false;
		}

		void InstallBtnClick(object sender, EventArgs e)
		{
			//
			SshUtil sshUtil = new SshUtil();
			LinkLabel label = pscpLink;
			if (label.Tag != null && job != null) {
				MeoServeur server = (MeoServeur)label.Tag;
				try {
					String serverTargetPath = server.getTranspo();
					sshUtil.installJob(server, serverTargetPath, job);
				} catch (Exception exception) {
					MessageBox.Show("Erreur envoi data : " + exception.Message + "\n" + exception.Source + "\n" + exception.StackTrace);
				}
			}
		}
		void OptionCC1heckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (optionCCheckBox.Checked) {
				optionC1CheckBox.Checked = false;
			}
		}
		void OptionCCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (optionC1CheckBox.Checked) {
				optionCCheckBox.Checked = false;
			}
			if(optionCCheckBox.Checked && job.getDetailClient()!=null) {
				MessageBox.Show("Absents:"+job.getDetailClient(), "Controle fichiers client");
			}
		}
		void OptionSCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (optionS1CheckBox.Checked) {
				optionSCheckBox.Checked = false;
			}
			if(optionSCheckBox.Checked && job.getDetailStock()!=null) {
				MessageBox.Show("Absents:"+job.getDetailStock(), "Controle fichiers Stock");
			}
			
		}
		void OptionS1CheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (optionSCheckBox.Checked) {
				optionS1CheckBox.Checked = false;
			}
		}
		void OptionJCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (optionDCheckBox.Checked) {
				optionJCheckBox.Checked = false;
			}
			if(optionJCheckBox.Checked && job.getDetailJoint()!=null) {
				MessageBox.Show("Absents:"+job.getDetailJoint(), "Controle fichiers Joints");
			}
		}
		void OptionDCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			if (optionJCheckBox.Checked) {
				optionDCheckBox.Checked = false;
			}
			if(optionDCheckBox.Checked && job.getDetailDoc()!=null) {
				MessageBox.Show("Absents:"+job.getDetailDoc(), "Controle fichiers Doc & Ord");
			}
			
		}
		void VisuJobLabelClick(object sender, EventArgs e)
		{
			completeOptions();
			prepareVisu(visuJobLabel, mouliActionUtil.getJobContent(pathLabel.Text, options, configDto));
		}
		void VisuScriptLabelClick(object sender, EventArgs e)
		{
			completeOptions();
			prepareVisu(visuScriptLabel, mouliActionUtil.getScriptContent(pathLabel.Text, options, configDto));
		}

		void prepareVisu(Label label, String contenu)
		{
			if (!1.Equals(label.Tag)) {
				label.Tag = 1;
				label.BackColor = Color.AntiqueWhite;
				visuRichTexBox.Tag = "j";
				doVisu(contenu);
				
			} else {
				label.BackColor = Color.LightGray;
				label.Tag = 0;
				visuRichTexBox.Tag = null;
			}
		}
		void doVisu(string str)
		{
			//visuRichTexBox.Text = str;
			visuRichTexBox.Clear();
			string[] tablo = str.Split('\n');
			for(int i=0;i<tablo.Length;i++) {
				String ligne = tablo[i]+"\n";
				Color color=Color.DarkBlue;
				if (ligne.StartsWith("#", StringComparison.Ordinal)) {
					color = Color.DarkGreen;
				}
				richTextBoxUtil.dcolorit(visuRichTexBox, ligne, color);
			}
			
			
			//visuRichTexBox.Enabled=false;
			visuRichTexBox.Visible = !visuRichTexBox.Visible;
			visuRichTexBox.Top = 20;
			visuRichTexBox.Left = 10;
			visuRichTexBox.Width = 550;
			visuRichTexBox.Height = 320;
			visuRichTexBox.BringToFront();
		}
		void AnalyseLabelClick(object sender, EventArgs e)
		{
			completeOptions();
			job = mouliActionUtil.doAnalyse(pathLabel.Text, options, configDto);
			analyseJob(job);
		}
		void PropositionMailsListBoxDoubleClick(object sender, EventArgs e)
		{
			if(propositionMailsListBox.SelectedItem!=null) {
				emailTextbox.Text = propositionMailsListBox.SelectedItem.ToString();
			}
		}
		private void TimerEventProcessor(Object myObject, EventArgs myEventArgs) {
			
			try {
				if(progressBoxText!=null) {
					progressTextBox.Text  = progressBoxText;
					progressBoxText=null;
				}
				if(toolStripStatusLabelText!=null) {
					toolStripStatusLabel1.Text =toolStripStatusLabelText;
					toolStripStatusLabelText=null;
				}
				if(toolStripProgressBarValue>=0) {
					toolStripProgressBar1.Value=toolStripProgressBarValue;
					toolStripProgressBarValue=-1;
				}
				if(finalFlag) {
					finalFlag=false;
					goButton.Enabled = true;
					uploadButton.Enabled = true;
					if (pscpLink.Tag != null) {
						pscpLink.Visible = true;
					}
				}
				if(installBtnEnabled) {
					installBtn.Enabled = true;
					installBtnEnabled=false;
				}
				if(finalUploadFlag) {
					toolStripProgressBarValue = 0;
					goButton.Enabled = true;
					uploadButton.Enabled = true;
					toolStripStatusLabelText = "done, unzip...";
				}

			} catch (Exception exception) {
				LOGGER.Error(exception);
			}
		}
		
	}
}