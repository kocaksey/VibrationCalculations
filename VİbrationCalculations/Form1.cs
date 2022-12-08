using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VİbrationCalculations
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbFFSM.SelectedIndex = 0;
        }
        double fn = 0;
        double[] knArray = { 9.87, 39.5, 88.8, 158, 247 };
        double[] ResultArray = new double[5];
        //s
        double f = 0;


        private void btnCalcSFC_Click(object sender, EventArgs e)
        {
            double k;
            double m;

            double.TryParse(txtSp.Text, out k);
            double.TryParse(txtM.Text, out m);
            if (txtSp.Text == "" || txtM.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                hz1.Visible = true;
                f = (1 / (2 * Math.PI)) * Math.Sqrt(k * 1000 / m);
                f = Math.Round(f, 2);
                lbHz.Text = Convert.ToString(f);
            }

        }

        private void btnResetSFC_Click(object sender, EventArgs e)
        {
            lbHz.Text = "";
            hz1.Visible = false;
            txtSp.Text = "";
            txtM.Text = "";

        }

        private void txtSp_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtSp.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtSp.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtSp.Text.StartsWith("0") && !txtSp.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }

        }

        private void txtM_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txtM.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txtM.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txtM.Text.StartsWith("0") && !txtM.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }

        }

        private void btnCalculateSSB_Click(object sender, EventArgs e)
        {
            double elasticity;
            double inertia;
            double beamLength;
            double w;
            int j = 0;
            double g = 9806.0;
            double.TryParse(txtElCant.Text, out elasticity);
            double.TryParse(txtInCant.Text, out inertia);
            double.TryParse(txtBeamCant.Text, out beamLength);
            double.TryParse(txtWCant.Text, out w);
            if (txtElCant.Text == "" || txtInCant.Text == "" || txtBeamCant.Text == "" || txtWCant.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {

                foreach (double kn in knArray)
                {
                    fn = ((kn / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / (w * Math.Pow(beamLength, 4))));
                    fn = Math.Round(fn, 2);
                    ResultArray[j] = fn;
                    j += 1;
                }
                lbRsCant1.Text = Convert.ToString(ResultArray[0]);
                lbRsCant2.Text = Convert.ToString(ResultArray[1]);
                lbRsCant3.Text = Convert.ToString(ResultArray[2]);
                lbRsCant4.Text = Convert.ToString(ResultArray[3]);
                lbRsCant5.Text = Convert.ToString(ResultArray[4]);
                hz1SSB.Visible = true;
                hz2SSB.Visible = true;
                hz3SSB.Visible = true;
                hz4SSB.Visible = true;
                hz5SSB.Visible = true;

            }

        }

        private void btnResetSSB_Click(object sender, EventArgs e)
        {
            txtWCant.Text = "";
            txtBeamCant.Text = "";
            txtInCant.Text = "";
            txtElCant.Text = "";
            hz1SSB.Visible = false;
            hz2SSB.Visible = false;
            hz3SSB.Visible = false;
            hz4SSB.Visible = false;
            hz5SSB.Visible = false;
            lbRsCant1.Text = "";
            lbRsCant2.Text = "";
            lbRsCant3.Text = "";
            lbRsCant4.Text = "";
            lbRsCant5.Text = "";

        }

        private void txtElCant_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtElCant);
        }

        private void txtInCant_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtInCant);
        }

        private void txtBeamCant_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtBeamCant);
        }

        private void txtWCant_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtWCant);
        }
        public void CharDetect(KeyPressEventArgs e, TextBox txt)
        {
            e.Handled = !(Char.IsNumber(e.KeyChar) || e.KeyChar == 8 || e.KeyChar == 46);
            if (txt.Text.Length == 0)
            {
                if (e.KeyChar == '.')
                {
                    e.Handled = true;
                }
            }
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == '.' && txt.Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
            if (txt.Text.StartsWith("0") && !txt.Text.StartsWith("0.") && e.KeyChar != '\b' && e.KeyChar != (int)'.')
            {
                e.Handled = true;
            }
        }

        private void Units_DrawItem_1(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush _textBrush;

            // Get the item from the collection.
            TabPage _tabPage = Units.TabPages[e.Index];

            // Get the real bounds for the tab rectangle.
            Rectangle _tabBounds = Units.GetTabRect(e.Index);

            if (e.State == DrawItemState.Selected)
            {

                // Draw a different background color, and don't paint a focus rectangle.
                _textBrush = new SolidBrush(Color.LightGray);
                g.FillRectangle(Brushes.Gray, e.Bounds);
            }
            else
            {
                _textBrush = new System.Drawing.SolidBrush(e.ForeColor);
                e.DrawBackground();
            }
            // Use our own font.
            Font _tabFont = new Font("Microsoft Sans Serif", 8.0f, FontStyle.Bold, GraphicsUnit.Point);

            // Draw string. Center the text.
            StringFormat _stringFlags = new StringFormat();
            _stringFlags.Alignment = StringAlignment.Center;
            _stringFlags.LineAlignment = StringAlignment.Center;
            g.DrawString(_tabPage.Text, _tabFont, _textBrush, _tabBounds, new StringFormat(_stringFlags));
        }

        double fnfx = 0;
        double fnCM = 0;
        double fnCM2 = 0;
        double[] knArrayfx = { 22.4, 61.7, 121, 200, 299 };
        double[] ResultArrayfx = new double[5];
        private void btnCalculateFixed_Click_1(object sender, EventArgs e)
        {
            double elasticity;
            double inertia;
            double beamLength;
            double w;
            double m;
            int j = 0;
            double g = 9806.0;
            double.TryParse(txtElFixed.Text, out elasticity);
            double.TryParse(txtInFixed.Text, out inertia);
            double.TryParse(txtBeamFixed.Text, out beamLength);
            double.TryParse(txtWFixed.Text, out w);
            double.TryParse(txtMFixed.Text, out m);
            if (txtElFixed.Text == "" || txtInFixed.Text == "" || txtBeamFixed.Text == "" || txtWFixed.Text == "" || txtMFixed.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                foreach (double kn in knArrayfx)
                {
                    fnfx = ((kn / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / (w * Math.Pow(beamLength, 4))));
                    fnfx = Math.Round(fnfx, 2);
                    ResultArrayfx[j] = fnfx;
                    j += 1;
                }
                lbRsFx1.Text = Convert.ToString(ResultArrayfx[0]);
                lbRsFx2.Text = Convert.ToString(ResultArrayfx[1]);
                lbRsFx3.Text = Convert.ToString(ResultArrayfx[2]);
                lbRsFx4.Text = Convert.ToString(ResultArrayfx[3]);
                lbRsFx5.Text = Convert.ToString(ResultArrayfx[4]);
                lbRsFx1.TextAlign = ContentAlignment.MiddleLeft;
                lbRsFx2.TextAlign = ContentAlignment.MiddleLeft;
                lbRsFx3.TextAlign = ContentAlignment.MiddleLeft;
                lbRsFx4.TextAlign = ContentAlignment.MiddleLeft;
                lbRsFx5.TextAlign = ContentAlignment.MiddleLeft;
                lbRsFx1.Anchor = AnchorStyles.Left;
                lbRsFx2.Anchor = AnchorStyles.Left;
                lbRsFx3.Anchor = AnchorStyles.Left;
                lbRsFx4.Anchor = AnchorStyles.Left;
                lbRsFx5.Anchor = AnchorStyles.Left;

                hz1Fx.Visible = true;
                hz2Fx.Visible = true;
                hz3Fx.Visible = true;
                hz4Fx.Visible = true;
                hz5Fx.Visible = true;
                hz6Fx.Visible = true;
                hz7Fx.Visible = true;
                fnCM = ((13.86 / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / (m * Math.Pow(beamLength, 3))));
                fnCM = Math.Round(fnCM, 2);
                lbCenterLoad.Text = Convert.ToString(fnCM);
                fnCM2 = ((13.86 / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / ((0.383 * w * Math.Pow(beamLength, 4)) + (m * Math.Pow(beamLength, 3)))));
                fnCM2 = Math.Round(fnCM2, 2);
                lbCenterLoad2.Text = Convert.ToString(fnCM2);
                lbCenterLoad.Visible = true;
                lbCenterLoad2.Visible = true;
            }

        }


        private void btnResetFx_Click(object sender, EventArgs e)
        {
            txtWFixed.Text = "";
            txtBeamFixed.Text = "";
            txtInFixed.Text = "";
            txtElFixed.Text = "";
            txtMFixed.Text = "";
            hz1Fx.Visible = false;
            hz2Fx.Visible = false;
            hz3Fx.Visible = false;
            hz4Fx.Visible = false;
            hz5Fx.Visible = false;
            hz6Fx.Visible = false;
            hz7Fx.Visible = false;
            lbRsFx1.Text = "";
            lbRsFx2.Text = "";
            lbRsFx3.Text = "";
            lbRsFx4.Text = "";
            lbRsFx5.Text = "";
            lbCenterLoad.Text = "";
            lbCenterLoad2.Text = "";
        }

        private void txtElFixed_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtElFixed);
        }

        private void txtInFixed_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtInFixed);
        }

        private void txtBeamFixed_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtBeamFixed);
        }

        private void txtWFixed_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtWFixed);
        }

        private void txtMFixed_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtMFixed);
        }


        double fncb = 0;
        double[] knArraycb = { 3.52, 22, 61.7, 121, 200 };
        double[] ResultArraycb = new double[5];


        private void btnResetCb_Click(object sender, EventArgs e)
        {
            txtWCantcb.Text = "";
            txtBeamCantcb.Text = "";
            txtInCantcb.Text = "";
            txtElCantcb.Text = "";
            hz1cb.Visible = false;
            hz2cb.Visible = false;
            hz3cb.Visible = false;
            hz4cb.Visible = false;
            hz5cb.Visible = false;
            lbRsCant1cb.Text = "";
            lbRsCant2cb.Text = "";
            lbRsCant3cb.Text = "";
            lbRsCant4cb.Text = "";
            lbRsCant5cb.Text = "";
        }

        private void btnCalculateCb_Click(object sender, EventArgs e)
        {
            double elasticity;
            double inertia;
            double beamLength;
            double w;
            int j = 0;
            double g = 9806.0;
            double.TryParse(txtElCantcb.Text, out elasticity);
            double.TryParse(txtInCantcb.Text, out inertia);
            double.TryParse(txtBeamCantcb.Text, out beamLength);
            double.TryParse(txtWCantcb.Text, out w);
            if (txtElCantcb.Text == "" || txtInCantcb.Text == "" || txtBeamCantcb.Text == "" || txtWCantcb.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {

                foreach (double kn in knArraycb)
                {
                    fncb = ((kn / (2.0 * Math.PI)) * Math.Sqrt((elasticity * inertia * g * 1000) / (w * Math.Pow(beamLength, 4))));
                    fncb = Math.Round(fncb, 2);
                    ResultArraycb[j] = fncb;
                    j += 1;
                }
                lbRsCant1cb.Text = Convert.ToString(ResultArraycb[0]);
                lbRsCant2cb.Text = Convert.ToString(ResultArraycb[1]);
                lbRsCant3cb.Text = Convert.ToString(ResultArraycb[2]);
                lbRsCant4cb.Text = Convert.ToString(ResultArraycb[3]);
                lbRsCant5cb.Text = Convert.ToString(ResultArraycb[4]);
                hz1cb.Visible = true;
                hz2cb.Visible = true;
                hz3cb.Visible = true;
                hz4cb.Visible = true;
                hz5cb.Visible = true;

            }
        }



        private void txtElCantcb_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtElCantcb);
        }

        private void txtInCantcb_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtInCantcb);
        }

        private void txtBeamCantcb_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtBeamCantcb);
        }

        private void txtWCantcb_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtWCantcb);
        }


        double fnsdf = 0;
        double wnsdf = 0;
        double timesdf = 0;
        double ccsdf = 0;
        double cccsdf = 0;
        double wdsdf = 0;
        double qsdf = 0;
        double trsdf = 0;
        double fdsdf = 0;

    

        private void btnCalcSdf_Click(object sender, EventArgs e)
        {
            double m;
            double k;
            double c;
            double ohm;
            double.TryParse(txtMass.Text, out m);
            double.TryParse(txtK.Text, out k);
            double.TryParse(txtC.Text, out c);
            double.TryParse(txtHarmonic.Text, out ohm);

            if (txtMass.Text == "" || txtK.Text == "" || txtC.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else if (txtHarmonic.Text == "" && txtHarmonic.Enabled == true)
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                wnsdf = Math.Sqrt(k / m);

                fnsdf = wnsdf / (2 * Math.PI);

                timesdf = 1 / fnsdf;

                ccsdf = 2 * m * wnsdf;
                cccsdf = c * ccsdf;
                wdsdf = wnsdf * (Math.Sqrt(1 - Math.Pow(c, 2)));
                qsdf = 1 / (2 * c);
                trsdf = Math.Sqrt((1 + Math.Pow(2 * c * ohm / wnsdf, 2)) / (Math.Pow(1 - Math.Pow(ohm / wnsdf, 2), 2) + Math.Pow(2 * c * ohm / wnsdf, 2)));
                fdsdf = wdsdf / (2 * Math.PI);
                wnsdf = Math.Round(wnsdf, 2);
                fnsdf = Math.Round(fnsdf, 2);
                timesdf = Math.Round(timesdf, 2);
                ccsdf = Math.Round(ccsdf, 2);
                cccsdf = Math.Round(cccsdf, 2);
                wdsdf = Math.Round(wdsdf, 2);
                qsdf = Math.Round(qsdf, 2);
                trsdf = Math.Round(trsdf, 2);
                fdsdf = Math.Round(fdsdf, 2);
        

                lbWn.Text = Convert.ToString(wnsdf);
                lbFn.Text = Convert.ToString(fnsdf);
                lbT.Text = Convert.ToString(timesdf);
                lbCc.Text = Convert.ToString(ccsdf);
                lbC.Text = Convert.ToString(cccsdf);
                lbWd.Text = Convert.ToString(wdsdf);
                lbFd.Text = Convert.ToString(fdsdf);
                lbQ.Text = Convert.ToString(qsdf);
                lbTr.Text = Convert.ToString(trsdf);

                if (cmbFF.SelectedIndex == 0)
                {
                    lbTr.Text = "";
                }

                hz1sdf.Visible = true;
                hz2sdf.Visible = true;
                hz3sdf.Visible = true;
                hz4sdf.Visible = true;
                hz5sdf.Visible = true;

            }
        }

        private void btnResetSdf_Click(object sender, EventArgs e)
        {
            hz1sdf.Visible = false;
            hz2sdf.Visible = false;
            hz3sdf.Visible = false;
            hz4sdf.Visible = false;
            hz5sdf.Visible = false;

            lbWn.Text = "";
            lbFn.Text = "";
            lbT.Text = "";
            lbCc.Text = "";
            lbC.Text = "";
            lbWd.Text = "";
            lbFd.Text = "";
            lbQ.Text = "";
            lbTr.Text = "";
            txtMass.Text = "";
            txtK.Text = "";
            txtC.Text = "";
            txtHarmonic.Text = "";
            cmbFF.SelectedIndex = 0;
        }

        private void cmbFF_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbFF.Text == "Forced")
            {
                txtHarmonic.Enabled = true;
            }
            else
            {
                txtHarmonic.Enabled = false;
                txtHarmonic.Text = "";
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            cmbFF.SelectedIndex = 0;
        }

        private void txtMass_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtMass);
        }

        private void txtK_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtK);
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtC);
        }

        private void txtHarmonic_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtHarmonic);
        }

        
        double kTv;
        double jTv;
        double fTv;

        private void btnCalcTv_Click(object sender, EventArgs e)
        {
            double ps;
            double sho;
            double shi;
            double shL;
            double g;
            double mJ;
            double.TryParse(txtDen.Text, out ps);
            double.TryParse(txtSho.Text, out sho);
            double.TryParse(txtShi.Text, out shi);
            double.TryParse(txtShL.Text, out shL);
            double.TryParse(txtGTv.Text, out g);
            double.TryParse(txtJTv.Text, out mJ);

            if (txtDen.Text == "" || txtSho.Text == "" || txtShi.Text == "" || txtShL.Text == "" || txtGTv.Text == "" || txtJTv.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                kTv = (Math.PI / 2) * (Math.Pow((sho / 2), 4) - Math.Pow((shi / 2), 4));
                jTv = ((0.001 * ps * Math.PI * ((Math.Pow(sho, 2) - Math.Pow(shi, 2)) / 4)* shL) / 2) * (Math.Pow((shi / 2), 2) + Math.Pow((sho / 2), 2));
                fTv = (1 / (2 * Math.PI)) * Math.Sqrt(((g * 1000000000) * kTv) / ((mJ + (jTv / 3)) * shL));
                kTv = Math.Round(kTv, 2);
                lbKTv.Text = Convert.ToString(kTv);
                jTv = Math.Round(jTv, 2);
                lbJTv.Text = Convert.ToString(jTv);
                fTv = Math.Round(fTv, 2);
                lbFTv.Text = Convert.ToString(fTv);

                hz1Tv.Visible = true;
                hz2Tv.Visible = true;
                hz3Tv.Visible = true;

                //
                //


            }
        }

        private void btnResetTv_Click(object sender, EventArgs e)
        {
            hz1Tv.Visible = false;
            hz2Tv.Visible = false;
            hz3Tv.Visible = false;
            lbFTv.Text = "";
            lbJTv.Text = "";
            lbKTv.Text = "";
            txtDen.Text = "";
            txtSho.Text = "";
            txtShi.Text = "";
            txtShL.Text = "";
            txtGTv.Text = "";
            txtJTv.Text = "";
        }

        private void txtDen_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtDen);
        }

        private void txtSho_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtSho);
        }

        private void txtShi_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtShi);
        }

        private void txtShL_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtShL);
        }

        private void txtGTv_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtGTv);
        }

        private void txtJTv_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtHarmonic);
        }

        double f1 = 0;
        double f2 = 0;
        double f3 = 0;





       

        private void btnCalcSVC_Click(object sender, EventArgs e)
        {
            double tenSVC;
            double beamSVC;
            double lenSVC;
            double.TryParse(txtTnSVC.Text, out tenSVC);
            double.TryParse(txtBmSVC.Text, out beamSVC);
            double.TryParse(txtUlSVC.Text, out lenSVC);

            if (txtTnSVC.Text == "" || txtBmSVC.Text == "" || txtUlSVC.Text == "")
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                f1 = (Math.PI / (2 * Math.PI)) * Math.Sqrt((tenSVC * 9805) / (lenSVC * Math.Pow(beamSVC, 2)));
                f2 = (2 * Math.PI / (2 * Math.PI)) * Math.Sqrt((tenSVC * 9805) / (lenSVC * Math.Pow(beamSVC, 2)));
                f3 = (3 * Math.PI / (2 * Math.PI)) * Math.Sqrt((tenSVC * 9805) / (lenSVC * Math.Pow(beamSVC, 2)));
                f1 = Math.Round(f1, 2);
                f2 = Math.Round(f2, 2);
                f3 = Math.Round(f3, 2);
                lbF1SVC.Text = Convert.ToString(f1);
                lbF2SVC.Text = Convert.ToString(f2);
                lbF3SVC.Text = Convert.ToString(f3);
                hz1SVC.Visible = true;
                hz2SVC.Visible = true;
                hz3SVC.Visible = true;
            }
        }

        private void btnResetSVC_Click(object sender, EventArgs e)
        {
            lbF1SVC.Text = "";
            lbF2SVC.Text = "";
            lbF3SVC.Text = "";
            hz1SVC.Visible = false;
            hz2SVC.Visible = false;
            hz3SVC.Visible = false;
            txtTnSVC.Text = "";
            txtBmSVC.Text = "";
            txtUlSVC.Text = "";
        }

        private void txtTnSVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtTnSVC);
        }

        private void txtBmSVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtBmSVC);
        }

        private void txtUlSVC_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtUlSVC);
        }


        double fSm = 0;
        double dSm = 0;
        double vSm = 0;
        double aSm = 0;

        private void cmbFFSM_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFFSM.SelectedItem.ToString() == "Frequency, Displacement")
            {
                lbCh1SM.Text = "Frequency";
                lbCh2SM.Text = "Displacement (peak-to-peak)";
                lb11SM.Text = "Hz";
                lb21SM.Text = "mm";
            }
            if (cmbFFSM.SelectedItem.ToString() == "Frequency, Velocity")
            {
                lbCh1SM.Text = "Frequency";
                lbCh2SM.Text = "Velocity (peak)";
                lb11SM.Text = "Hz";
                lb21SM.Text = "mm/s";
            }
            if (cmbFFSM.SelectedItem.ToString() == "Frequency, Acceleration")
            {
                lbCh1SM.Text = "Frequency";
                lbCh2SM.Text = "Acceleration (peak)";
                lb11SM.Text = "Hz";
                lb21SM.Text = "g";
            }
            if (cmbFFSM.SelectedItem.ToString() == "Displacement, Velocity")
            {
                lbCh1SM.Text = "Displacement (peak-to-peak)";
                lbCh2SM.Text = "Velocity (peak)";
                lb11SM.Text = "mm";
                lb21SM.Text = "mm/s";
            }
            if (cmbFFSM.SelectedItem.ToString() == "Displacement, Acceleration")
            {
                lbCh1SM.Text = "Displacement (peak-to-peak)";
                lbCh2SM.Text = "Acceleration (peak)";
                lb11SM.Text = "mm";
                lb21SM.Text = "g";
            }
            if (cmbFFSM.SelectedItem.ToString() == "Velocity, Acceleration")
            {
                lbCh1SM.Text = "Velocity (peak)";
                lbCh2SM.Text = "Acceleration (peak)";
                lb11SM.Text = "mm/s";
                lb21SM.Text = "g";
            }
        }





        private void btnCalcSM_Click(object sender, EventArgs e)
        {
            double disp;
            double freq;
            double acc;
            double vel;
            freq = 0.0;
            disp = 0.0;
            acc = 0.0;
            vel = 0.0;

            if (lbCh1SM.Text == "Frequency")
            {
                double.TryParse(txtSM.Text, out freq);
            }

            if (lbCh1SM.Text == "Velocity (peak)")
            {
                double.TryParse(txtSM.Text, out vel);
            }
            if (lbCh1SM.Text == "Displacement (peak-to-peak)")
            {
                double.TryParse(txtSM.Text, out disp);
            }
            if (lbCh2SM.Text == "Displacement (peak-to-peak)")
            {
                double.TryParse(txtSMx.Text, out disp);
            }
            if (lbCh2SM.Text == "Velocity (peak)")
            {
                double.TryParse(txtSMx.Text, out vel);
            }
            if (lbCh2SM.Text == "Acceleration (peak)")
            {
                double.TryParse(txtSMx.Text, out acc);
            }
            if (freq == 0.0)
            {
                freq = vel / (disp * Math.PI);
            }



            if (txtSMx.Text == "" || txtSM.Text == "" || cmbFFSM.SelectedItem == null)
            {
                MessageBox.Show("Please enter values!", "Warning!");
            }
            else
            {
                freq = Math.Round(freq, 3);
                lbFSM.Text = Convert.ToString(freq);

                dSm = disp * (Math.Sin(2 * Math.PI * freq)) / 2;
                dSm = Math.Round(dSm, 3);
                lbDSM.Text = Convert.ToString(dSm);


                vSm = (Math.PI) * freq * disp;
                vSm = Math.Round(vSm, 3);
                lbVSM.Text = Convert.ToString(vSm);
                aSm = (2 * Math.Pow((Math.PI * freq), 2) * disp) / 9805;
                aSm = Math.Round(aSm, 3);
                lbASM.Text = Convert.ToString(aSm);
                if (lbCh1SM.Text == "Displacement (peak-to-peak)" || lbCh2SM.Text == "Displacement (peak-to-peak)")
                {
                    lbDSM.Text = Convert.ToString(disp);
                }
                if (lbCh1SM.Text == "Velocity (peak)" || lbCh2SM.Text == "Velocity (peak)")
                {
                    lbVSM.Text = Convert.ToString(vel);
                }
                if (lbCh1SM.Text == "Acceleration (peak)" || lbCh2SM.Text == "Acceleration (peak)")
                {
                    lbASM.Text = Convert.ToString(acc);
                }
                if (lbCh1SM.Text == "Velocity (peak)" && lbCh2SM.Text == "Acceleration (peak)")
                {
                    fSm = ((acc / vel) * 9805) / (2 * Math.PI);
                    fSm = Math.Round(fSm, 3);
                    lbFSM.Text = Convert.ToString(fSm);
                    dSm = vel / (Math.PI * fSm);
                    dSm = Math.Round(dSm, 3);
                    lbDSM.Text = Convert.ToString(dSm);
                }
             
                if (cmbFFSM.SelectedItem.ToString() == "Frequency, Velocity")
                {
                    dSm = vel / (freq * Math.PI);
                    dSm = Math.Round(dSm, 3);
                    lbDSM.Text = Convert.ToString(dSm);
                    aSm = 2 * Math.Pow((Math.PI * freq), 2) * dSm / 9805;
                    aSm = Math.Round(aSm, 3);
                    lbASM.Text = Convert.ToString(aSm);
                }
                if (cmbFFSM.SelectedItem.ToString() == "Frequency, Acceleration")
                {
                    dSm = acc / (2 * (Math.Pow(Math.PI * freq, 2))) * 9805;
                    dSm = Math.Round(dSm, 3);
                    lbDSM.Text = Convert.ToString(dSm);
                    vSm = dSm * Math.PI * freq;
                    vSm = Math.Round(vSm, 3);
                    lbVSM.Text = Convert.ToString(vSm);
                }
                if (cmbFFSM.SelectedItem.ToString() == "Displacement, Acceleration")
                {
                    fSm = Math.Sqrt((acc * 9805) / (2 * Math.PI * Math.PI * disp));
                    fSm = Math.Round(fSm, 3);
                    lbFSM.Text = Convert.ToString(fSm);
                    vSm = disp * fSm * Math.PI;
                    vSm = Math.Round(vSm, 3);
                    lbVSM.Text = Convert.ToString(vSm);
                }
                hz1SM.Visible = true;
                hz2SM.Visible = true;
                hz3SM.Visible = true;
                hz4SM.Visible = true;
            }
        }

        private void btnResetSM_Click(object sender, EventArgs e)
        {
            cmbFFSM.SelectedIndex = 0;
            txtSM.Text = "";
            txtSMx.Text = "";
            lbASM.Text = "";
            lbVSM.Text = "";
            lbFSM.Text = "";
            lbDSM.Text = "";
            hz1SM.Visible = false;
            hz2SM.Visible = false;
            hz3SM.Visible = false;
            hz4SM.Visible = false;
        }

        private void Units_MouseClick(object sender, MouseEventArgs e)
        {
            Action<Control.ControlCollection> func = null;

            func = (controls) =>
            {
                foreach (Control control in controls)
                    if (control is TextBox)
                        (control as TextBox).Clear();
                    else
                        func(control.Controls);
            };

            func(Controls);

            cmbFFSM.SelectedIndex = 0;
            txtSM.Text = "";
            txtSMx.Text = "";
            lbASM.Text = "";
            lbVSM.Text = "";
            lbFSM.Text = "";
            lbDSM.Text = "";
            hz1SM.Visible = false;
            hz2SM.Visible = false;
            hz3SM.Visible = false;
            hz4SM.Visible = false;

            lbF1SVC.Text = "";
            lbF2SVC.Text = "";
            lbF3SVC.Text = "";
            hz1SVC.Visible = false;
            hz2SVC.Visible = false;
            hz3SVC.Visible = false;
            txtTnSVC.Text = "";
            txtBmSVC.Text = "";
            txtUlSVC.Text = "";

            hz1Tv.Visible = false;
            hz2Tv.Visible = false;
            hz3Tv.Visible = false;
            lbFTv.Text = "";
            lbJTv.Text = "";
            lbKTv.Text = "";
            txtDen.Text = "";
            txtSho.Text = "";
            txtShi.Text = "";
            txtShL.Text = "";
            txtGTv.Text = "";
            txtJTv.Text = "";

            hz1sdf.Visible = false;
            hz2sdf.Visible = false;
            hz3sdf.Visible = false;
            hz4sdf.Visible = false;
            hz5sdf.Visible = false;

            lbWn.Text = "";
            lbFn.Text = "";
            lbT.Text = "";
            lbCc.Text = "";
            lbC.Text = "";
            lbWd.Text = "";
            lbFd.Text = "";
            lbQ.Text = "";
            lbTr.Text = "";
            txtMass.Text = "";
            txtK.Text = "";
            txtC.Text = "";
            txtHarmonic.Text = "";
            cmbFF.SelectedIndex = 0;

            txtWCantcb.Text = "";
            txtBeamCantcb.Text = "";
            txtInCantcb.Text = "";
            txtElCantcb.Text = "";
            hz1cb.Visible = false;
            hz2cb.Visible = false;
            hz3cb.Visible = false;
            hz4cb.Visible = false;
            hz5cb.Visible = false;
            lbRsCant1cb.Text = "";
            lbRsCant2cb.Text = "";
            lbRsCant3cb.Text = "";
            lbRsCant4cb.Text = "";
            lbRsCant5cb.Text = "";

            txtWFixed.Text = "";
            txtBeamFixed.Text = "";
            txtInFixed.Text = "";
            txtElFixed.Text = "";
            txtMFixed.Text = "";
            hz1Fx.Visible = false;
            hz2Fx.Visible = false;
            hz3Fx.Visible = false;
            hz4Fx.Visible = false;
            hz5Fx.Visible = false;
            hz6Fx.Visible = false;
            hz7Fx.Visible = false;
            lbRsFx1.Text = "";
            lbRsFx2.Text = "";
            lbRsFx3.Text = "";
            lbRsFx4.Text = "";
            lbRsFx5.Text = "";
            lbCenterLoad.Text = "";
            lbCenterLoad2.Text = "";

            txtWCant.Text = "";
            txtBeamCant.Text = "";
            txtInCant.Text = "";
            txtElCant.Text = "";
            hz1SSB.Visible = false;
            hz2SSB.Visible = false;
            hz3SSB.Visible = false;
            hz4SSB.Visible = false;
            hz5SSB.Visible = false;
            lbRsCant1.Text = "";
            lbRsCant2.Text = "";
            lbRsCant3.Text = "";
            lbRsCant4.Text = "";
            lbRsCant5.Text = "";

            lbHz.Text = "";
            hz1.Visible = false;
            txtSp.Text = "";
            txtM.Text = "";



        }

        private void txtSM_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtSM);
        }

        private void txtSMx_KeyPress(object sender, KeyPressEventArgs e)
        {
            CharDetect(e, txtSMx);
        }
    }


}
