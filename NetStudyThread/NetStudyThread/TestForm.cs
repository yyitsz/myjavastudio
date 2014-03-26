using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace NetStudyThread
{
    public class TestForm : Form
    {
        private Button btnButton;
        private Button btnDoit;
        private ListBox lstResults;
        public TestForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            btnButton = new Button();
            btnButton.Text = "Start";
            btnButton.Name = "btnButton";
            btnButton.Location = new System.Drawing.Point(0, 0);
            btnButton.Click += new EventHandler(btnButton2_Click);

            btnDoit = new Button();
            btnDoit.Text = "do it";
            btnDoit.Name = "btnDoit";
            btnDoit.Location = new System.Drawing.Point(40, 0);
            btnDoit.Click += new EventHandler(btnDoit_Click);

            lstResults = new ListBox();
            lstResults.Name = "lstResults";
            lstResults.Location = new System.Drawing.Point(0, 24);
            lstResults.Size = new System.Drawing.Size(500, 500);

            this.Text = "Test";
            this.Size = new System.Drawing.Size(700, 700);
            this.Controls.Add(btnButton);
            this.Controls.Add(lstResults);
            this.Controls.Add(btnDoit);

        }

        void btnDoit_Click(object sender, EventArgs e)
        {
            CancellationTokenSource source = new CancellationTokenSource();
            CancellationToken token = source.Token;

            Task<List<int>> taskWithFactoryAndState =
                Task.Factory.StartNew<List<int>>(stateObjec =>
                {
                    List<int> ints = new List<int>();
                    for (int i = 0; i < (int)stateObjec; i++)
                    {
                        ints.Add(i);
                        if (i > 100)
                        {
                            InvalidOperationException ex =
                                new InvalidOperationException("oh,no its > 100");
                            ex.Source = "taskWithFactoryAndState";
                            throw ex;
                        }
                    }
                    return ints;
                }, 200,token).ContinueWith<List<int>>(ant =>
                    {
                        try
                        {
                            lstResults.DataSource = ant.Result;
                            return ant.Result;
                        }
                        catch (AggregateException aggEx)
                        {
                            StringBuilder sb = new StringBuilder();

                            foreach (Exception ex in aggEx.InnerExceptions)
                            {
                                sb.AppendFormat("Caught exception '{0}'", ex.Message);
                                sb.AppendLine();
                            }

                            MessageBox.Show(sb.ToString());
                            return new List<int>();
                        }
                    },token,
                    TaskContinuationOptions.None,
                    TaskScheduler.FromCurrentSynchronizationContext());
        }
        void btnButton2_Click(object sender, EventArgs e)
        {
            Task<List<int>> taskWithFactoryAndState =
                Task.Factory.StartNew<List<int>>(stateObjec =>
                    {
                        List<int> ints = new List<int>();
                        for (int i = 0; i < (int)stateObjec; i++)
                        {
                            ints.Add(i);
                            if (i > 100)
                            {
                                InvalidOperationException ex =
                                    new InvalidOperationException("oh,no its > 100");
                                ex.Source = "taskWithFactoryAndState";
                                throw ex;
                            }
                        }
                        return ints;
                    }, 200);

            try
            {
                taskWithFactoryAndState.Wait();

                if (taskWithFactoryAndState.IsFaulted == false)
                {
                    lstResults.DataSource = taskWithFactoryAndState.Result;
                }

   
            }
            catch (AggregateException aggEx)
            {
                StringBuilder sb = new StringBuilder();

                foreach (Exception ex in aggEx.InnerExceptions)
                {
                    sb.AppendFormat("Caught exception '{0}'", ex.Message);
                    sb.AppendLine();
                }

                MessageBox.Show(sb.ToString());
            }
            finally
            {
                taskWithFactoryAndState.Dispose();
            }
        }
   

        void btnButton_Click(object sender, EventArgs e)
        {
            Task<List<int>> taskWithFactoryAndState =
                Task.Factory.StartNew<List<int>>(stateObjec =>
                    {
                        List<int> ints = new List<int>();
                        for (int i = 0; i < (int)stateObjec; i++)
                        {
                            ints.Add(i);
                            if (i > 100)
                            {
                                InvalidOperationException ex =
                                    new InvalidOperationException("oh,no its > 100");
                                ex.Source = "taskWithFactoryAndState";
                                throw ex;
                            }
                        }
                        return ints;
                    }, 100);

            while (!taskWithFactoryAndState.IsCompleted)
            {
                Thread.Sleep(500);
            }

            if (taskWithFactoryAndState.IsFaulted == false)
            {
                lstResults.DataSource = taskWithFactoryAndState.Result;
            }
            else
            {
                StringBuilder sb = new StringBuilder();
                AggregateException taskEx = taskWithFactoryAndState.Exception;
                foreach (Exception ex in taskEx.InnerExceptions)
                {
                    sb.AppendFormat("Caught exception '{0}'", ex.Message);
                    sb.AppendLine();
                }

                MessageBox.Show(sb.ToString());
            }

            taskWithFactoryAndState.Dispose();
        }
    }
}
