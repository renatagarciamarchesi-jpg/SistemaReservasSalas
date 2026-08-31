using System;
using System.Linq;
using System.Windows.Forms;
using SistemaReservasSalas.Modelos;
using SistemaReservasSalas.Servicios;

namespace SistemaReservasSalas.Formularios
{
    public partial class FormGestionSalas : Form
    {
        public FormGestionSalas()
        {
            InitializeComponent();
        }

        private void FormGestionSalas_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            grid.DataSource = null;
            grid.DataSource = ContextoDatos.RepoSalas.Listar()
                .Select(s => new
                {
                    s.Id,
                    s.Nombre,
                    s.Ubicacion,
                    s.Capacidad,
                    Equipamiento = s.EquipamientoResumen
                }).ToList();
        }

        private void grid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var fila = grid.Rows[e.RowIndex];
            txtId.Text = fila.Cells["Id"].Value?.ToString();
            txtNombre.Text = fila.Cells["Nombre"].Value?.ToString();
            txtUbicacion.Text = fila.Cells["Ubicacion"].Value?.ToString();
            txtCapacidad.Text = fila.Cells["Capacidad"].Value?.ToString();

            var sala = ContextoDatos.RepoSalas.Obtener(txtId.Text);
            txtEquipamiento.Text = sala != null ? string.Join(", ", sala.Equipamiento) : "";
        }

        private bool ValidarCampos(out int capacidad)
        {
            capacidad = 0;
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Id y Nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!int.TryParse(txtCapacidad.Text, out capacidad) || capacidad <= 0)
            {
                MessageBox.Show("La capacidad debe ser un número entero mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int capacidad)) return;

            try
            {
                var equipamiento = txtEquipamiento.Text.Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                var sala = new SalaReunion(txtId.Text.Trim(), txtNombre.Text.Trim(), txtUbicacion.Text.Trim(), capacidad, equipamiento);
                ContextoDatos.RepoSalas.Agregar(sala);
                CargarGrilla();
                btnLimpiar_Click(sender, e);
                MessageBox.Show("Sala agregada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al agregar sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos(out int capacidad)) return;

            try
            {
                var equipamiento = txtEquipamiento.Text.Split(',')
                    .Select(x => x.Trim())
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();

                var sala = new SalaReunion(txtId.Text.Trim(), txtNombre.Text.Trim(), txtUbicacion.Text.Trim(), capacidad, equipamiento);
                ContextoDatos.RepoSalas.Actualizar(sala);
                CargarGrilla();
                btnLimpiar_Click(sender, e);
                MessageBox.Show("Sala modificada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al modificar sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione una sala de la grilla para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmar = MessageBox.Show($"¿Eliminar la sala '{txtId.Text}'?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmar != DialogResult.Yes) return;

            try
            {
                ContextoDatos.RepoSalas.Eliminar(txtId.Text.Trim());
                CargarGrilla();
                btnLimpiar_Click(sender, e);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al eliminar sala", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtId.Text = txtNombre.Text = txtUbicacion.Text = txtCapacidad.Text = txtEquipamiento.Text = "";
        }
    }
}
