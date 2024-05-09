using SGE.Aplicacion;
using SGE.Repositorios;


RepositorioExpedienteTXT repoExpedientes=new RepositorioExpedienteTXT();
var expa=new CasoDeUsoExpedienteAlta(repoExpedientes);



expa.Ejecutar(new Expediente(repoExpedientes.AsignarID(),"Tu mama",DateTime.Now,DateTime.Now,1,(EstadoExpediente)0 ));