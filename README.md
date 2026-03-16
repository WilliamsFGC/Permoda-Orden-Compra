# Preguntas al final del documento

¿Por qué decidio esa estructura?
	Porque se basa en arquitectura limpia, puedo separar responsabilidades, dar a entender el negocio de la aplicación, nos dice que se necesita, todo apunta hacia el dominio, el como se hace lo pensamos luego.

	y respecto a los eventos, porque puedo desacoplar las dependencias y reaccionen respecto a las acciones en el sistema

¿Qué ventajas aporta clean architecture?
	Separar responsabilidades, poder escalar y mantener la aplicación

¿Dónde ubica los domain Events y porque?
	En el domain, porque son eventos importantes del dominio que se toman en cuenta dentro del mismo.

¿Cómo escalaría este sistema?
	Podemos distribuir los eventos entre diferentes servicios existentes y nuevos, y con la base de datos usamos
	la migración de Entity framework para los versionamientos.

¿Cómo lo convertitía en un sistema distribuido?
	Por medio de los eventos y el RabbitMQ, ya sería un sistema distribuido para operar en diferentes servidores,
	dependemos de la configuración de base de datos y del RabbitMQ

¿Cómo manejaría escenarios de alta concurrencia?
	Podríamos manejarlo con encolamiento, y procesar las peticiones que van llegando al sistema