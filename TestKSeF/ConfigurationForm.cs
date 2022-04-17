/*
 * Author: Gbb Software 2002
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestKSeF
{
    partial class ConfigurationForm : Form
    {
        public ConfigurationForm()
        {
            InitializeComponent();

            // URL list
            this.URL_BindingSource.DataSource = new List<DropDownString>()
            { 
                new DropDownString("Testy: https://ksef-test.mf.gov.pl/api", "https://ksef-test.mf.gov.pl/api"),
                new DropDownString("Demo: https://ksef-demo.mf.gov.pl/api", "https://ksef-demo.mf.gov.pl/api"),
                new DropDownString("Produkcja: https://ksef.mf.gov.pl/api", "https://ksef.mf.gov.pl/api"),
            };
            // PublicKey list
            this.PublicKey_BindingSource.DataSource = new List<DropDownString>()
            {
                new DropDownString("Testy: MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuWosgHSpiRLadA0fQbzshi5TluliZfDsJujPlyYqp6A3qnzS3WmHxtwgO58uTbemQ1HCC2qwrMwuJqR6l8tgA4ilBMDbEEtkzgbjkJ6xoEqBptgxivP/ovOFYYoAnY6brZhXytCamSvjY9KI0g0McRk24pOueXT0cbb0tlwEEjVZ8NveQNKT2c1EEE2cjmW0XB3UlIBqNqiY2rWF86DcuFDTUy+KzSmTJTFvU/ENNyLTh5kkDOmB1SY1Zaw9/Q6+a4VJ0urKZPw+61jtzWmucp4CO2cfXg9qtF6cxFIrgfbtvLofGQg09Bh7Y6ZA5VfMRDVDYLjvHwDYUHg2dPIk0wIDAQAB",
                                          "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAuWosgHSpiRLadA0fQbzshi5TluliZfDsJujPlyYqp6A3qnzS3WmHxtwgO58uTbemQ1HCC2qwrMwuJqR6l8tgA4ilBMDbEEtkzgbjkJ6xoEqBptgxivP/ovOFYYoAnY6brZhXytCamSvjY9KI0g0McRk24pOueXT0cbb0tlwEEjVZ8NveQNKT2c1EEE2cjmW0XB3UlIBqNqiY2rWF86DcuFDTUy+KzSmTJTFvU/ENNyLTh5kkDOmB1SY1Zaw9/Q6+a4VJ0urKZPw+61jtzWmucp4CO2cfXg9qtF6cxFIrgfbtvLofGQg09Bh7Y6ZA5VfMRDVDYLjvHwDYUHg2dPIk0wIDAQAB"),
                new DropDownString("Demo: MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwocTwdNgt2+PXJ2fcB7k1kn5eFUTXBeep9pHLx6MlfkmHLvgjVpQy1/hqMTFfZqw6piFOdZMOSLgizRKjb1CtDYhWncg0mML+yhVrPyHT7bkbqfDuM2ku3q8ueEOy40SEl4jRMNvttkWnkvf/VTy2TwA9X9vTd61KJmDDZBLOCVqsyzdnELKUE8iulXwTarDvVTx4irnz/GY+y9qod+XrayYndtU6/kDgasAAQv0pu7esFFPMr83Nkqdu6JD5/0yJOl5RShQXwlmToqvpih2+L92x865/C4f3n+dZ9bgsKDGSkKSqq7Pz+QnhF7jV/JAmtJBCIMylxdxI/xfDHZ5XwIDAQAB",
                                          "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAwocTwdNgt2+PXJ2fcB7k1kn5eFUTXBeep9pHLx6MlfkmHLvgjVpQy1/hqMTFfZqw6piFOdZMOSLgizRKjb1CtDYhWncg0mML+yhVrPyHT7bkbqfDuM2ku3q8ueEOy40SEl4jRMNvttkWnkvf/VTy2TwA9X9vTd61KJmDDZBLOCVqsyzdnELKUE8iulXwTarDvVTx4irnz/GY+y9qod+XrayYndtU6/kDgasAAQv0pu7esFFPMr83Nkqdu6JD5/0yJOl5RShQXwlmToqvpih2+L92x865/C4f3n+dZ9bgsKDGSkKSqq7Pz+QnhF7jV/JAmtJBCIMylxdxI/xfDHZ5XwIDAQAB"),
                new DropDownString("Produkcja: MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtCVoNVHGeaOwmzuFMiScJozTbh+ULVtQYmRNTON+20ilBOqkHrJRUZCtXUg0w+ztYMvWFr4U74ykGMnEYODT7l2F8JGuJeE9YGK8hKqaY5h0YYxJW7fWybZOxQJhwXzuasjKt/OHYWrI6SmL96bSanr6MwGNr6yiNQV3R6EFB/wpZ4scwh8ZfEs0kk29uIgZVEbkq+9n/xRQjbAtaQs6eiDb4AUOBd7nm4+Uis5goHkjTtJwmhcpQq5Vw7lug3FUsn7/luNyCVhaR4BkpB3NVexxepYSByJneFrOgOh/3GilK2a47WPAEVG3hRQAiGBUR0m7Ev7WYboQtA1TI7hc6wIDAQAB",
                                          "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAtCVoNVHGeaOwmzuFMiScJozTbh+ULVtQYmRNTON+20ilBOqkHrJRUZCtXUg0w+ztYMvWFr4U74ykGMnEYODT7l2F8JGuJeE9YGK8hKqaY5h0YYxJW7fWybZOxQJhwXzuasjKt/OHYWrI6SmL96bSanr6MwGNr6yiNQV3R6EFB/wpZ4scwh8ZfEs0kk29uIgZVEbkq+9n/xRQjbAtaQs6eiDb4AUOBd7nm4+Uis5goHkjTtJwmhcpQq5Vw7lug3FUsn7/luNyCVhaR4BkpB3NVexxepYSByJneFrOgOh/3GilK2a47WPAEVG3hRQAiGBUR0m7Ev7WYboQtA1TI7hc6wIDAQAB"),
            };

        }

        private void ConfigurationForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.configurationLineBindingSource.DataSource = Program.Configuration.Lines;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

        }

        private void ConfigurationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Program.SaveConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }
    }

    public class DropDownString
    {
        public string Value { get; set; }
        public string Name { get; set; }

        public DropDownString(string _Name, string _value)
        {
            Value = _value;
            Name = _Name;
        }
    }

}
