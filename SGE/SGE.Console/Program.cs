using SGE.Aplicacion;
using SGE.Repositorios;

RepositorioTramiteTXT repoTramite = new RepositorioTramiteTXT() ;
var tram = new CasoDeUsoTramiteModificacion (repoTramite); 

tram.Ejecutar (new Tramite (17,5,(EtiquetaTramite)2,"MUJICON",DateTime.Now,DateTime.Now,1)) ;