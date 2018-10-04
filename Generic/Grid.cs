//Development by Kelmer Ashley Comas Cardona © 2015

using System;
using System.Data;
using System.Windows.Forms;


namespace Generic
{
    public static class Grid
    {
        public enum eTypes { ENTERO, DECIMAL, FECHAHORA, TEXTO }

        public static void ClearGrid(DataGridView dataGrid)
        {
            try
            {
                if (dataGrid != null)
                {
                    dataGrid.EndEdit();
                    DataTable table = (DataTable)dataGrid.DataSource;
                    if (table != null) table.Rows.Clear();
                }
            }
            catch { throw; }
        }

        public static void ValidateFormatCellInGrid(string columnName, object formattedValue, eTypes type, Boolean validateNegative = false, string text = null)
        {
            try
            {
                string value = null;
                object valueReal;

                if (formattedValue != null)
                {
                    value = formattedValue.ToString();

                    if (!String.IsNullOrEmpty(value))
                    {
                        switch (type)
                        {
                            case eTypes.DECIMAL:
                                try { valueReal = Convert.ToDecimal(value); }
                                catch
                                {
                                    string message = "El valor [" + value + "] de la columna [" + text + "] no cumple con el formato numerico decimal.";
                                    throw new Exception(message);
                                }

                                if (validateNegative && ((decimal)valueReal) < 0)
                                    throw new Exception("El valor de la columna [" + text + "] no puede ser un numero negativo");

                                break;
                            case eTypes.ENTERO:
                                try { valueReal = Convert.ToInt64(value); }
                                catch
                                {
                                    string message = "El valor [" + value + "] de la columna [" + text + "] no cumple con el formato numerico entero.";
                                    throw new Exception(message);
                                }

                                if (validateNegative && ((long)valueReal) < 0)
                                    throw new Exception("El valor de la columna [" + text + "] no puede ser un numero negativo");

                                break;
                            case eTypes.FECHAHORA:
                                try { Convert.ToDateTime(value); }
                                catch
                                {
                                    string message = "El valor [" + value + "] de la columna [" + text + "] no cumple con el formato de fecha y hora.";
                                    throw new Exception(message);
                                }
                                break;
                        }
                    }
                }
            }
            catch { throw; }
        }


        public static void ValidateIsEmptyCellInGrid(string columnName, object formattedValue, string text = null)
        {
            try
            {
                text = (String.IsNullOrEmpty(text)) ? columnName : text;
                string message = "El valor de la columna [" + text + "] es obligatorio. No puede estar vacio.";

                if (formattedValue != null)
                {
                    if (String.IsNullOrEmpty(formattedValue.ToString()))
                        throw new Exception(message);
                }
                else throw new Exception(message);

            }
            catch { throw; }
        }


        public static void ValidateCompleteCellInGrid(string columnName, object formattedValue, eTypes type, Boolean validateNegative = false, string text = null)
        {
            try
            {
                Grid.ValidateIsEmptyCellInGrid(columnName, formattedValue, text);
                Grid.ValidateFormatCellInGrid(columnName, formattedValue, type, validateNegative, text);
            }
            catch { throw; }
        }

        public static bool IsGridInEditMode(DataGridView grid)
        {
            try
            {
                return ((grid.Enabled &&
                         grid.IsCurrentCellInEditMode) || grid.IsCurrentCellDirty || grid.IsCurrentRowDirty
                       ) ? true : false;
            }
            catch { throw; }
        }


        public static bool IsGridInEdit(DataGridView grid)
        {
            try
            {
                return (grid.Enabled &&
                        (grid.IsCurrentRowDirty ||
                         grid.IsCurrentCellDirty)) ? true : false;
            }
            catch { throw; }
        }

        public static object ReturnGridVulueEdit(DataGridView grid, int rowIndex, int columnIndex)
        {
            try
            {
                if (rowIndex >= 0 && columnIndex >= 0)
                {
                    object value = grid.Rows[rowIndex].Cells[columnIndex].GetEditedFormattedValue(rowIndex, DataGridViewDataErrorContexts.Commit);
                    if (value != null)
                        if (String.IsNullOrEmpty(value.ToString())) value = null;
                    return value;
                }
                else return null;
            }
            catch { throw; }
        }

        public static object ReturnGridVulueEdit(DataGridView grid, int rowIndex, string columnName)
        {
            try
            {
                if (rowIndex >= 0 && !String.IsNullOrEmpty(columnName))
                {
                    object value = grid.Rows[rowIndex].Cells[columnName].GetEditedFormattedValue(rowIndex, DataGridViewDataErrorContexts.Commit);
                    if (value != null)
                        if (String.IsNullOrEmpty(value.ToString())) value = null;
                    return value;
                }
                else return null;
            }
            catch { throw; }
        }

    }
}
