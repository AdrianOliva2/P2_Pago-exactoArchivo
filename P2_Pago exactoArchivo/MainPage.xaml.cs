namespace P2_Pago_exactoArchivo;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private void calcularTotal()
	{	
		double total = Math.Round((Convert.ToDouble(lblSubtotal.Text.Replace("€", "")) + Convert.ToDouble(lblPropina.Text.Replace("€", ""))), 2);
		if (total - Math.Round(total) == 0)
		{
			lblTotal.Text = $"{total},00€";
		}
		else
		{
			lblTotal.Text = $"{total}€";
        }
    }

	private void _stepper_ValueChanged(object sender, ValueChangedEventArgs e)
	{
        lblSubtotal.Text = $"{Math.Round((Convert.ToDouble(entryCuenta.Text.Replace("€", "").Replace(".", ",")) / _stepper.Value), 2)}€";
        lblPropina.Text = $"{Math.Round(((Convert.ToDouble(lblSubtotal.Text.Replace("€", "")) * sliderPorcentajePropina.Value) / 100), 2)}€";
        calcularTotal();
	}

	private void sliderPorcentajePropina_ValueChanged(object sender, ValueChangedEventArgs e)
	{
		lblPropinaTextPorcentaje.Text = $"Propina: {Math.Round(sliderPorcentajePropina.Value, 2)}%";
        lblPropina.Text = $"{Math.Round((((Convert.ToDouble(lblSubtotal.Text.Replace("€", "")) * sliderPorcentajePropina.Value) / 100) / _stepper.Value), 2)}€";
		calcularTotal();
    }

	private void btn10Porcentaje_Clicked(object sender, EventArgs e)
	{
		sliderPorcentajePropina.Value = 10;
	}

	private void btn15Porcentaje_Clicked(object sender, EventArgs e)
	{
        sliderPorcentajePropina.Value = 15;
    }

	private void btn20Porcentaje_Clicked(object sender, EventArgs e)
	{
        sliderPorcentajePropina.Value = 20;
    }

	private void entryCuenta_TextChanged(object sender, TextChangedEventArgs e)
	{
		try
		{
			if (entryCuenta.Text != null)
				if (!entryCuenta.Text.Contains(" ") && !entryCuenta.Text.Contains("€") && !entryCuenta.Text.Contains("$"))
					lblSubtotal.Text = $"{Math.Round((Convert.ToDouble(entryCuenta.Text.Replace("€", "").Replace(".", ",")) / _stepper.Value), 2)}€";
				else
					entryCuenta.Text = e.OldTextValue;
			else
			{
				entryCuenta.Text = "";
				lblSubtotal.Text = "0.00€";
			}
        }
		catch (FormatException)
		{
			if (e.NewTextValue != "")
			{
				entryCuenta.Text = e.OldTextValue;
			} 
			else
			{
				lblSubtotal.Text = "0.00€";
			}
		}
		catch (Exception) {}
        lblPropina.Text = $"{Math.Round(((Convert.ToDouble(lblSubtotal.Text.Replace("€", "")) * sliderPorcentajePropina.Value) / 100), 2)}€";
        calcularTotal();
    }
}

