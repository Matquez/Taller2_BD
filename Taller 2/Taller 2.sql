#Creamos la base de datos
CREATE DATABASE IF NOT EXISTS base_Taller2;

#Creamos las tablas con ayuda de visual paradigm
CREATE TABLE IF NOT EXISTS administrador (
	id_admin int(10) NOT NULL AUTO_INCREMENT,
    password varchar(255) NOT NULL,
    PRIMARY KEY (id_admin)
    )ENGINE=INNODB;
INSERT INTO administrador VALUES(12341,'12341');
    
CREATE TABLE IF NOT EXISTS cliente (
	id_cliente int(10) NOT NULL AUTO_INCREMENT,
    rut_cliente varchar(255) NOT NULL UNIQUE,
    nombre_cliente varchar(255) NOT NULL,
    fecha_creacion_cli date,
    direccion varchar(255) NOT NULL,
    PRIMARY KEY (id_cliente),
    INDEX (fecha_creacion_cli)
    )ENGINE=INNODB;
    
CREATE TABLE IF NOT EXISTS cliente_cuenta_corriente (
	id_cliente int(10) NOT NULL,
    id_cuenta_corriente int(10) NOT NULL,
    PRIMARY KEY (id_cliente, id_cuenta_corriente)
    )ENGINE=INNODB;
    
CREATE TABLE IF NOT EXISTS cuenta_corriente (
	id_cuenta_corriente int(10) NOT NULL AUTO_INCREMENT,
    numero_cuenta int(10) NOT NULL UNIQUE,
    saldo_cuenta int(10) NOT NULL,
    fecha_estado_actual date,
    id_estado_actual int(10) NOT NULL,
    PRIMARY KEY (id_cuenta_corriente),
    INDEX (fecha_estado_actual)
    )ENGINE=INNODB;
    
CREATE TABLE IF NOT EXISTS estado_cuenta (
	id_estado_cuenta int(10) NOT NULL AUTO_INCREMENT,
    nom_estado varchar(255) NOT NULL UNIQUE,
    PRIMARY KEY (id_estado_cuenta)
    )ENGINE=INNODB;
    
CREATE TABLE IF NOT EXISTS tipo_transaccion (
	id_tipo_transaccion int(10) NOT NULL AUTO_INCREMENT,
    tipo_transaccion varchar(255) NOT NULL UNIQUE,
    PRIMARY KEY (id_tipo_transaccion)
    )ENGINE=INNODB;
    
CREATE TABLE IF NOT EXISTS transaccion_cuenta (
	id_transaccion int(10) NOT NULL AUTO_INCREMENT,
    id_cuenta_corriente int(10) NOT NULL,
    monto_transaccion int(10) NOT NULL,
    fecha_transaccion date,
    hora_transaccion time,
    id_tipo_transaccion int(10) NOT NULL,
    PRIMARY KEY (id_transaccion),
    INDEX (fecha_transaccion),
    INDEX (hora_transaccion)
    )ENGINE=INNODB;
    
ALTER TABLE transaccion_cuenta ADD CONSTRAINT FKtransaccio992628 FOREIGN KEY (id_tipo_transaccion) REFERENCES tipo_transaccion (id_tipo_transaccion);
ALTER TABLE transaccion_cuenta ADD CONSTRAINT FKtransaccio816884 FOREIGN KEY (id_cuenta_corriente) REFERENCES cuenta_corriente (id_cuenta_corriente);
ALTER TABLE cuenta_corriente ADD CONSTRAINT FKcuenta_cor13352 FOREIGN KEY (id_estado_actual) REFERENCES estado_cuenta (id_estado_cuenta);
ALTER TABLE cliente_cuenta_corriente ADD CONSTRAINT FKcliente_cu789950 FOREIGN KEY (id_cuenta_corriente) REFERENCES cuenta_corriente (id_cuenta_corriente);
ALTER TABLE cliente_cuenta_corriente ADD CONSTRAINT FKcliente_cu752864 FOREIGN KEY (id_cliente) REFERENCES cliente (id_cliente);
