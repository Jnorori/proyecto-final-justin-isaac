'------------------------------------------------------------------------------
' <generado automáticamente>
'     Este código fue generado por una herramienta.
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código. 
' </generado automáticamente>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Partial Public Class Admin

    '''<summary>
    '''Control lblUsuario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblUsuario As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control lblMensaje.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents lblMensaje As Global.System.Web.UI.WebControls.Label

    '''<summary>
    '''Control txtCedulaPaciente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtCedulaPaciente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtNombrePaciente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNombrePaciente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtApellidosPaciente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtApellidosPaciente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtTelefonoPaciente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTelefonoPaciente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtFechaNacimientoPaciente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFechaNacimientoPaciente As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btnAgregarPaciente.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregarPaciente As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control gvPacientes.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gvPacientes As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control txtNombreDoctor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtNombreDoctor As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtEspecialidadDoctor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtEspecialidadDoctor As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtTelefonoDoctor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtTelefonoDoctor As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btnAgregarDoctor.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregarDoctor As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control gvDoctores.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gvDoctores As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control ddlDoctorHorarioNuevo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlDoctorHorarioNuevo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control txtDiaSemanaHorario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtDiaSemanaHorario As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtHoraInicioHorario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtHoraInicioHorario As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtHoraFinHorario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtHoraFinHorario As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btnAgregarHorario.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregarHorario As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control gvHorarios.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gvHorarios As Global.System.Web.UI.WebControls.GridView

    '''<summary>
    '''Control ddlPacienteCitaNuevo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlPacienteCitaNuevo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control ddlDoctorCitaNuevo.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents ddlDoctorCitaNuevo As Global.System.Web.UI.WebControls.DropDownList

    '''<summary>
    '''Control txtFechaHoraCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtFechaHoraCita As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtEstadoCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtEstadoCita As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control txtObservacionesCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents txtObservacionesCita As Global.System.Web.UI.WebControls.TextBox

    '''<summary>
    '''Control btnAgregarCita.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents btnAgregarCita As Global.System.Web.UI.WebControls.Button

    '''<summary>
    '''Control gvCitas.
    '''</summary>
    '''<remarks>
    '''Campo generado automáticamente.
    '''Para modificarlo, mueva la declaración del campo del archivo del diseñador al archivo de código subyacente.
    '''</remarks>
    Protected WithEvents gvCitas As Global.System.Web.UI.WebControls.GridView
End Class
