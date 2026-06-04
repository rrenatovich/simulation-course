using LabMM;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LabMM
{
    public partial class Form1 : Form
    {
        private readonly Label titleLabel = new Label();

        private readonly Panel inputPanel = new Panel();
        private readonly Panel outputPanel = new Panel();

        private readonly Label lambdaLabel = new Label();
        private readonly Label muLabel = new Label();
        private readonly Label requestsLabel = new Label();
        private readonly Label serversLabel = new Label();
        private readonly Label queueLabel = new Label();

        private readonly NumericUpDown lambdaInput = new NumericUpDown();
        private readonly NumericUpDown muInput = new NumericUpDown();
        private readonly NumericUpDown requestsInput = new NumericUpDown();
        private readonly NumericUpDown serversInput = new NumericUpDown();
        private readonly NumericUpDown queueInput = new NumericUpDown();

        private readonly Button startButton = new Button();
        private readonly Button closeButton = new Button();

        private readonly Label outputTitleLabel = new Label();
        private readonly ListBox resultsList = new ListBox();

        public Form1()
        {
            InitializeCustomForm();
            CreateControls();
        }

        private void Form1_Load(object? sender, EventArgs e)
        {
        }

        private void InitializeCustomForm()
        {
            Text = "LabMM1 - M/M/N/K";
            StartPosition = FormStartPosition.CenterScreen;
            ClientSize = new Size(980, 620);
            MinimumSize = new Size(980, 620);
            BackColor = Color.FromArgb(18, 24, 33);
            Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
        }

        private void CreateControls()
        {
            titleLabel.Text = "M/M/*";
            titleLabel.Font = new Font("Segoe UI", 28F, FontStyle.Bold, GraphicsUnit.Point);
            titleLabel.ForeColor = Color.White;
            titleLabel.AutoSize = true;
            titleLabel.Location = new Point(28, 20);

            inputPanel.Location = new Point(28, 90);
            inputPanel.Size = new Size(320, 490);
            inputPanel.BackColor = Color.FromArgb(31, 39, 51);

            outputPanel.Location = new Point(370, 90);
            outputPanel.Size = new Size(580, 490);
            outputPanel.BackColor = Color.FromArgb(31, 39, 51);

            lambdaLabel.Text = "Интенсивность lambda";
            lambdaLabel.ForeColor = Color.White;
            lambdaLabel.AutoSize = true;
            lambdaLabel.Location = new Point(24, 28);

            lambdaInput.Location = new Point(28, 54);
            lambdaInput.Size = new Size(220, 25);
            lambdaInput.DecimalPlaces = 1;
            lambdaInput.Increment = 0.1M;
            lambdaInput.Minimum = 0.1M;
            lambdaInput.Maximum = 100M;
            lambdaInput.Value = 2.0M;

            muLabel.Text = "Интенсивность mu";
            muLabel.ForeColor = Color.White;
            muLabel.AutoSize = true;
            muLabel.Location = new Point(24, 98);

            muInput.Location = new Point(28, 124);
            muInput.Size = new Size(220, 25);
            muInput.DecimalPlaces = 1;
            muInput.Increment = 0.1M;
            muInput.Minimum = 0.1M;
            muInput.Maximum = 100M;
            muInput.Value = 2.5M;

            requestsLabel.Text = "Число заявок N";
            requestsLabel.ForeColor = Color.White;
            requestsLabel.AutoSize = true;
            requestsLabel.Location = new Point(24, 168);

            requestsInput.Location = new Point(28, 194);
            requestsInput.Size = new Size(220, 25);
            requestsInput.Minimum = 1;
            requestsInput.Maximum = 1000000;
            requestsInput.Increment = 100;
            requestsInput.Value = 1000;

            serversLabel.Text = "Количество приборов";
            serversLabel.ForeColor = Color.White;
            serversLabel.AutoSize = true;
            serversLabel.Location = new Point(24, 238);

            serversInput.Location = new Point(28, 264);
            serversInput.Size = new Size(220, 25);
            serversInput.Minimum = 1;
            serversInput.Maximum = 50;
            serversInput.Value = 2;

            queueLabel.Text = "Максимальная очередь";
            queueLabel.ForeColor = Color.White;
            queueLabel.AutoSize = true;
            queueLabel.Location = new Point(24, 308);

            queueInput.Location = new Point(28, 334);
            queueInput.Size = new Size(220, 25);
            queueInput.Minimum = 0;
            queueInput.Maximum = 1000;
            queueInput.Value = 5;

            startButton.Text = "Запустить моделирование";
            startButton.Location = new Point(28, 396);
            startButton.Size = new Size(220, 48);
            startButton.FlatStyle = FlatStyle.Flat;
            startButton.FlatAppearance.BorderSize = 0;
            startButton.BackColor = Color.FromArgb(62, 134, 230);
            startButton.ForeColor = Color.White;
            startButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            startButton.Click += start_button_Click;

            closeButton.Text = "Закрыть";
            closeButton.Location = new Point(28, 454);
            closeButton.Size = new Size(220, 40);
            closeButton.FlatStyle = FlatStyle.Flat;
            closeButton.FlatAppearance.BorderSize = 0;
            closeButton.BackColor = Color.FromArgb(190, 78, 78);
            closeButton.ForeColor = Color.White;
            closeButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            closeButton.Click += button1_Click;

            outputTitleLabel.Text = "Результаты моделирования";
            outputTitleLabel.ForeColor = Color.White;
            outputTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point);
            outputTitleLabel.AutoSize = true;
            outputTitleLabel.Location = new Point(24, 22);

            resultsList.Location = new Point(28, 62);
            resultsList.Size = new Size(520, 388);
            resultsList.BorderStyle = BorderStyle.None;
            resultsList.BackColor = Color.FromArgb(20, 26, 36);
            resultsList.ForeColor = Color.White;
            resultsList.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            resultsList.ItemHeight = 19;

            inputPanel.Controls.Add(lambdaLabel);
            inputPanel.Controls.Add(lambdaInput);
            inputPanel.Controls.Add(muLabel);
            inputPanel.Controls.Add(muInput);
            inputPanel.Controls.Add(requestsLabel);
            inputPanel.Controls.Add(requestsInput);
            inputPanel.Controls.Add(serversLabel);
            inputPanel.Controls.Add(serversInput);
            inputPanel.Controls.Add(queueLabel);
            inputPanel.Controls.Add(queueInput);
            inputPanel.Controls.Add(startButton);
            inputPanel.Controls.Add(closeButton);

            outputPanel.Controls.Add(outputTitleLabel);
            outputPanel.Controls.Add(resultsList);

            Controls.Add(titleLabel);
            Controls.Add(inputPanel);
            Controls.Add(outputPanel);
        }

        private void start_button_Click(object? sender, EventArgs e)
        {
            double lambda = (double)lambdaInput.Value;
            double mu = (double)muInput.Value;
            int totalRequests = (int)requestsInput.Value;
            int serversCount = (int)serversInput.Value;
            int maxQueue = (int)queueInput.Value;

            QueueingSystem model = new QueueingSystem(lambda, mu, serversCount, maxQueue, totalRequests);
            MM1SimulationResult result = model.RunSimulation();

            resultsList.Items.Clear();
            resultsList.Items.Add("=== Статистика M/M/* ===");
            resultsList.Items.Add($"Всего заявок: {result.TotalRequests}");
            resultsList.Items.Add($"Количество приборов: {result.ServersCount}");
            resultsList.Items.Add($"Максимальная очередь: {result.MaxQueue}");
            resultsList.Items.Add($"Обслужено: {result.SuccessfulRequests}");
            resultsList.Items.Add($"Отказано: {result.RejectedRequests}");
            resultsList.Items.Add($"Вероятность отказа: {result.RejectProbability:P2}");
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            Close();
        }
    }
}