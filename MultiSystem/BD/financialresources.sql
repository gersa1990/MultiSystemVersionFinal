-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 13-10-2014 a las 01:34:19
-- Versión del servidor: 5.5.24-log
-- Versión de PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `financialresources`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `admins`
--

CREATE TABLE IF NOT EXISTS `admins` (
  `idAdmin` int(11) NOT NULL AUTO_INCREMENT,
  `nameAdmin` varchar(100) NOT NULL,
  `lastNameAdmin` varchar(100) NOT NULL,
  `userAdmin` varchar(30) NOT NULL,
  `passwordAdmin` varchar(30) NOT NULL,
  `idTypeAdmin` int(11) NOT NULL,
  PRIMARY KEY (`idAdmin`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=9 ;

--
-- Volcado de datos para la tabla `admins`
--

INSERT INTO `admins` (`idAdmin`, `nameAdmin`, `lastNameAdmin`, `userAdmin`, `passwordAdmin`, `idTypeAdmin`) VALUES
(1, 'Administrador', 'principal', 'adminPrincipal', 'adminPrincipal', 1),
(2, 'Angel trinidad', 'torrez ramirez', 'angel123', 'angelJornada1', 2),
(3, 'Angel trinidad', 'torrez ramirez', 'angel123', 'angelJornada2', 3),
(4, 'Jose Antonio', 'Apellidos', 'jose123', 'matutino', 4),
(5, 'jose antonio', 'apellidos asdasd', 'jose123', 'vespertino', 5),
(6, 'desvelado 1', 'apellidos', 'nocturno123', 'nocturno1', 6),
(7, 'desvelado 2', 'apellidos', 'nocturno123', 'nocturno2', 7),
(8, '..', '..', 'adminGral', 'adminGral', 100);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `services`
--

CREATE TABLE IF NOT EXISTS `services` (
  `idService` int(11) NOT NULL AUTO_INCREMENT,
  `keyPrice` varchar(7) NOT NULL,
  `descriptionPrice` varchar(150) NOT NULL,
  `amountPrice` int(15) NOT NULL,
  `type` varchar(100) NOT NULL,
  PRIMARY KEY (`idService`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=76 ;

--
-- Volcado de datos para la tabla `services`
--

INSERT INTO `services` (`idService`, `keyPrice`, `descriptionPrice`, `amountPrice`, `type`) VALUES
(1, '370-29', 'MORELIA', 1328, 'AMBULANCIA'),
(2, '370-29', 'URUAPAN', 1040, 'AMBULANCIA'),
(3, '370-29', 'N. ITALIA', 424, 'AMBULANCIA'),
(4, '370-29', 'APATZINGAN', 704, 'AMBULANCIA'),
(5, '370-29', 'ARIO DE ROSALES', 400, 'AMBULANCIA'),
(6, '370-29', 'PATZCUARO', 724, 'AMBULANCIA'),
(7, '202-03', 'BIOMETRIA HEMATICA', 35, 'LABORATORIO'),
(8, '193-06', 'TIPO SANGUINEO Y FACTOR RH', 33, 'LABORATORIO'),
(9, '201-27', 'TIPO DE SANGRADO', 48, 'LABORATORIO'),
(10, '201-29', 'TIEMPO DE COAGULACION', 48, 'LABORATORIO'),
(11, 'T201-31', 'T.P', 35, 'LABORATORIO'),
(12, '201-32', 'T.P.T', 37, 'LABORATORIO'),
(13, '210-07', 'RECUENTO DE PLAQUETAS', 30, 'LABORATORIO'),
(14, '193-00', 'QS(03)', 100, 'LABORATORIO'),
(15, '193-00', 'GLUCOSA', 30, 'LABORATORIO'),
(16, '193-00', 'UREA', 30, 'LABORATORIO'),
(17, '193-00', 'CREATININA', 37, 'LABORATORIO'),
(18, '193-00', 'QS(06) ', 233, 'LABORATORIO'),
(19, '193-07', 'ACIDO URICO', 37, 'LABORATORIO'),
(20, '193-12', 'COLESTEROL TOTAL', 54, 'LABORATORIO'),
(21, '197-02', 'TRIGLISERIDOS', 42, 'LABORATORIO'),
(22, '192-05', 'REACCIONES FEBRILES', 37, 'LABORATORIO'),
(23, '192-08', 'V.D.R.L (EMBARAZADAS GRATIS)', 37, 'LABORATORIO'),
(24, '192-15', 'FACTOR REUMATOIDE', 53, 'LABORATORIO'),
(25, '192-14', 'PROTEINA C REACTIVA', 53, 'LABORATORIO'),
(26, '192-16', 'ANTI ESTREPTOLISINAS (ASO)', 53, 'LABORATORIO'),
(27, '198-36', 'G.C.H  (PRUEBA DE EMBARAZO)', 96, 'LABORATORIO'),
(28, '200-02', 'COPROPARASITOSCOPIO 1-2-3', 35, 'LABORATORIO'),
(29, '199-00', 'EXAMEN GENERAL DE ORINA', 37, 'LABORATORIO'),
(30, '165-17', 'FERULAS DE YESO', 49, 'SIN SEGURO POPULAR'),
(31, '360-01', 'LAVADO GASTRICO', 98, 'SIN SEGURO POPULAR'),
(32, '010-01', 'CONSULTA GENERAL', 30, 'SIN SEGURO POPULAR'),
(33, '010-02', 'CONSULTA ESPECIALISTA', 50, 'SIN SEGURO POPULAR'),
(34, '030-03', 'CONSULTA DENTAL', 37, 'SIN SEGURO POPULAR'),
(35, '031-30', 'LIMPIEZA CABRITON', 54, 'SIN SEGURO POPULAR'),
(36, '080-10', 'PARTO NORMAL', 1500, 'SIN SEGURO POPULAR'),
(37, '360-03', 'VENOCLISIS', 100, ''),
(38, '360-04', 'I.V.', 30, 'SIN SEGURO POPULAR'),
(39, '360-05', 'I.M', 18, 'SIN SEGURO POPULAR'),
(40, '037-01', 'SUTURAS MAYORES', 67, 'SIN SEGURO POPULAR'),
(41, '080-31', 'CIRUGIA MENOR DENTRO DEL QUIROFANO', 761, 'SIN SEGURO POPULAR'),
(42, '080-38', 'EXTIRPACION DE LIPOMA', 761, 'SIN SEGURO POPULAR'),
(43, '165-17', 'REALIZACION DE FERULA DE YESO', 49, 'SIN SEGURO POPULAR'),
(44, '169-12', 'VENDAS DE YESO C/U', 49, 'SIN SEGURO POPULAR'),
(45, '360-02', 'SONDEO VESICAL', 83, 'SIN SEGURO POPULAR'),
(46, '360-06', 'VENDAJES COMPRENSIVOS ', 59, 'SIN SEGURO POPULAR'),
(47, '360-11', 'CURACIONES Y RETIRO DE PUNTOS', 43, 'SIN SEGURO POPULAR'),
(48, '360-12', 'NEBULIZACION', 16, 'SIN SEGURO POPULAR'),
(49, '034-01', 'LIMPIEZA DENTAL', 43, 'SIN SEGURO POPULAR'),
(50, '031-09', 'ENDODONCIA SIMPLE X PIEZA', 112, 'SIN SEGURO POPULAR'),
(51, '031-37', 'OBTURACION CON IONOMERO DE VIDRIO', 187, 'SIN SEGURO POPULAR'),
(52, '031-02', 'OBTURACION DE AMALGAMA', 50, 'SIN SEGURO POPULAR'),
(53, '010-05', 'CONSULTA URGENCIAS', 64, 'SIN SEGURO POPULAR'),
(54, '010-01', 'HOSPITALIZACION X DIA', 102, 'SIN SEGURO POPULAR'),
(55, '192-05', 'REACCIONES FEBRILES EN PLACA', 37, 'SIN SEGURO POPULAR'),
(56, '306-01', 'ULTRASONIDO', 200, 'SIN SEGURO POPULAR'),
(57, '360-13', 'LAVADO DE OIDO', 16, 'SIN SEGURO POPULAR'),
(58, '031-04', 'OBTURACION CON IRM O CON OXIDO DE ZINC', 26, 'SIN SEGURO POPULAR'),
(59, '031-29', 'CURACION DENTAL', 37, 'SIN SEGURO POPULAR'),
(60, '031-03', 'OBTURACION DE RESINA', 90, 'SIN SEGURO POPULAR'),
(61, '031-032', 'ODONTOXESIS', 71, 'SIN SEGURO POPULAR'),
(62, '020-03', 'FIMOSIS (CIRCUNSICION)', 368, 'SIN SEGURO POPULAR'),
(63, '031-10', 'EXODONCIA MULTIPLE', 144, 'SIN SEGURO POPULAR'),
(64, '040-19', 'DESINTOXICACION ALCOHOLICA', 679, 'SIN SEGURO POPULAR'),
(65, '031-69', 'EXTRACCION DEL TERCER MOLAR', 241, 'SIN SEGURO POPULAR'),
(66, '350-03', 'ELECTROCARDIOGRAMA', 58, 'SIN SEGURO POPULAR'),
(67, '010-06', 'OBSERVACION DE 2 A 12 HRS', 89, 'SIN SEGURO POPULAR'),
(68, '370-10', 'REPOSICION DE CARNET', 20, 'SIN SEGURO POPULAR'),
(69, '020-04', 'HERNIA INGUINAL', 2224, 'SIN SEGURO POPULAR'),
(70, '020-09', 'HERNIA HUMBILICAL', 3494, 'SIN SEGURO POPULAR'),
(71, '021-01', 'LIPOMAS QUISTES', 381, 'SIN SEGURO POPULAR'),
(72, '020-11', 'APENDISECTOMIA', 3569, 'SIN SEGURO POPULAR'),
(73, '020-12', 'EXTRACCION DE UNA', 106, 'SIN SEGURO POPULAR'),
(74, '034-01', 'DENTAL (PROFILAXIS)', 43, 'SIN SEGURO POPULAR'),
(75, '289', 'Servicio de ejempl', 123, 'AMBULANCIA');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicesdata`
--

CREATE TABLE IF NOT EXISTS `servicesdata` (
  `idServiceData` int(11) NOT NULL AUTO_INCREMENT,
  `folioPatient` varchar(30) NOT NULL,
  `namePatient` varchar(100) NOT NULL,
  `lastNamePatient` varchar(100) NOT NULL,
  `adressPatient` varchar(200) NOT NULL,
  `dateService` varchar(10) NOT NULL,
  `auxDate` varchar(10) NOT NULL,
  `hourService` varchar(5) NOT NULL,
  PRIMARY KEY (`idServiceData`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=80 ;

--
-- Volcado de datos para la tabla `servicesdata`
--

INSERT INTO `servicesdata` (`idServiceData`, `folioPatient`, `namePatient`, `lastNamePatient`, `adressPatient`, `dateService`, `auxDate`, `hourService`) VALUES
(55, '123123', 'Jse Antonio', 'Valdez Gonxzales', 'asd', '2014-08-09', '2014_08_10', '05:00'),
(56, '123123', 'JOSE', 'JOSE', 'ASD', '2014-08-12', '2014_08_12', '16:7'),
(57, 'GHJ', 'HJ', 'GHJ', 'GHJ', '2014-08-12', '2014_08_12', '16:8'),
(58, '6546569', 'PALOMA GISSEL', 'MENDOZA JURADO', 'EJIDO 145.  COLONIA MIGUEL HIDALGO', '2014-08-12', '2014_08_12', '16:17'),
(59, '6549876', 'PATRICIA', 'MORENO', 'EJIDO 4536', '2014-08-12', '2014_08_12', '16:19'),
(60, 'FGH', 'FGH', 'FGH', 'FGH', '2014-08-17', '2014_08_17', '15:13'),
(61, 'AD123', 'JOSE ANTONIO', 'CHAVEZ SOTO', 'LA HUACANA', '2014-09-09', '2014_09_09', '21:54'),
(62, 'ASD', 'GERSA', 'ASD', 'ASD', '2014-10-05', '2014_10_05', '22:51'),
(63, '23', 'SDF', 'SDF', 'SDF', '2014-10-05', '2014_10_05', '22:55'),
(64, '123', 'ASD', 'ASD', 'ASD', '2014-10-05', '2014_10_05', '22:59'),
(65, '123', 'QWE', 'QWE', 'QWE', '2014-10-05', '2014_10_05', '23:3'),
(66, 'ASD', 'ASD', 'ASD', 'ASD', '2014-10-05', '2014_10_05', '23:8'),
(67, 'ASD', 'ASD', 'ASD', 'ASD', '2014-10-05', '2014_10_05', '23:12'),
(68, 'ASD', 'ASD', 'ASD', 'ASD', '2014-10-05', '2014_10_05', '23:15'),
(69, 'SDF', 'SF', 'SDF', 'SDF', '2014-10-05', '2014_10_05', '23:16'),
(70, 'DFG', 'WERT', 'DFG', 'DFG', '2014-10-05', '2014_10_05', '23:17'),
(71, 'DFG', 'DFG', 'DFG', 'DFG', '2014-10-05', '2014_10_05', '23:17'),
(73, 'DFG', 'DFG', 'DFG', 'DFG', '2014-10-05', '2014_10_05', '23:19'),
(74, 'ASF', 'ASD', 'ASD', 'ASD', '2014-10-05', '2014_10_05', '23:23'),
(75, '123', '1123', '123', '123123', '2014-10-05', '2014_10_05', '23:26'),
(76, '123', '123', '123', '123', '2014-10-05', '2014_10_05', '23:28'),
(77, 'ER', 'WER', 'ERT', 'ER', '2014-10-05', '2014_10_05', '23:29'),
(78, '123123', 'TEST', 'TEST', 'ASD', '2014-10-08', '2014_10_08', '23:16'),
(79, 'ASD', 'ASD', 'ASD', 'ASD', '2014-10-08', '2014_10_08', '23:17');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `servicesprovided`
--

CREATE TABLE IF NOT EXISTS `servicesprovided` (
  `idProvided` int(11) NOT NULL AUTO_INCREMENT,
  `idServiceData` int(11) NOT NULL,
  `idService` int(11) NOT NULL,
  `idAdmin` int(11) NOT NULL,
  `reasonDiscount` varchar(200) DEFAULT NULL,
  `amountWithDiscount` int(20) DEFAULT NULL,
  PRIMARY KEY (`idProvided`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=204 ;

--
-- Volcado de datos para la tabla `servicesprovided`
--

INSERT INTO `servicesprovided` (`idProvided`, `idServiceData`, `idService`, `idAdmin`, `reasonDiscount`, `amountWithDiscount`) VALUES
(126, 55, 30, 1, NULL, 0),
(127, 56, 27, 1, '', 0),
(128, 57, 27, 1, '', 0),
(129, 58, 37, 1, 'XFDSGG', 90),
(130, 59, 37, 1, '', 0),
(131, 59, 37, 1, '', 0),
(132, 59, 37, 1, '', 0),
(133, 59, 37, 1, '', 0),
(134, 59, 37, 1, '', 0),
(135, 59, 37, 1, '', 0),
(136, 59, 37, 1, '', 0),
(137, 60, 1, 3, 'FGH', 567),
(138, 61, 2, 1, 'SDF', 12),
(139, 61, 37, 1, 'ESCASOS RECURSOS', 50),
(140, 61, 37, 1, 'ESCASOS RECURSOS', 50),
(141, 61, 19, 1, '', 0),
(142, 61, 18, 1, '', 0),
(143, 61, 20, 1, '', 0),
(144, 62, 1, 1, '', 0),
(145, 62, 2, 1, '', 0),
(146, 62, 2, 1, '', 0),
(147, 62, 2, 1, '', 0),
(148, 62, 74, 1, '', 0),
(149, 63, 5, 1, '', 0),
(150, 63, 2, 1, '', 0),
(151, 64, 1, 1, '', 0),
(152, 64, 1, 1, '', 0),
(153, 64, 1, 1, '', 0),
(154, 64, 2, 1, '', 0),
(155, 64, 2, 1, '', 0),
(156, 64, 2, 1, '', 0),
(157, 64, 2, 1, '', 0),
(158, 64, 2, 1, '', 0),
(159, 64, 74, 1, '', 0),
(160, 65, 1, 1, '', 0),
(161, 65, 1, 1, '', 0),
(162, 65, 1, 1, '', 0),
(163, 65, 1, 1, '', 0),
(164, 65, 1, 1, '', 0),
(165, 65, 2, 1, '', 0),
(166, 65, 2, 1, '', 0),
(167, 65, 2, 1, '', 0),
(168, 65, 73, 1, '', 0),
(169, 66, 2, 1, '', 0),
(170, 66, 3, 1, '', 0),
(171, 66, 74, 1, '', 0),
(172, 67, 1, 1, '', 0),
(173, 67, 39, 1, '', 0),
(174, 67, 41, 1, '', 0),
(175, 68, 1, 1, '', 0),
(176, 68, 74, 1, '', 0),
(177, 69, 3, 1, '', 0),
(178, 69, 5, 1, '', 0),
(179, 70, 4, 1, '', 0),
(180, 71, 1, 1, '', 0),
(187, 73, 2, 1, '', 0),
(188, 74, 3, 1, '', 0),
(189, 74, 17, 1, '', 0),
(190, 75, 2, 1, '', 0),
(191, 76, 3, 1, '', 0),
(192, 77, 1, 1, '', 0),
(193, 77, 1, 1, '', 0),
(194, 77, 1, 1, '', 0),
(195, 77, 1, 1, '', 0),
(196, 77, 1, 1, '', 0),
(197, 77, 63, 1, '', 0),
(198, 77, 64, 1, '', 0),
(199, 77, 74, 1, '', 0),
(200, 77, 73, 1, '', 0),
(201, 78, 1, 1, '', 0),
(202, 78, 3, 1, '', 0),
(203, 79, 1, 1, '', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `typeofadmins`
--

CREATE TABLE IF NOT EXISTS `typeofadmins` (
  `idTypeAdmin` int(11) NOT NULL AUTO_INCREMENT,
  `typeAdmin` varchar(40) NOT NULL,
  `workingHours` varchar(11) NOT NULL,
  PRIMARY KEY (`idTypeAdmin`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=101 ;

--
-- Volcado de datos para la tabla `typeofadmins`
--

INSERT INTO `typeofadmins` (`idTypeAdmin`, `typeAdmin`, `workingHours`) VALUES
(1, 'Administrador Principal', 'Todo el día'),
(2, 'JORNADA ACUMULADA 1', '09:00-13:00'),
(3, 'JORNADA ACUMULADA 2', '13:00-18:00'),
(4, 'MATUTINO', '08:00-13:00'),
(5, 'VESPERTINO', '13:00-20:00'),
(6, 'NOCTURNO A', '20:00-02:00'),
(7, 'NOCTURNO B', '02:00-08:00'),
(100, 'Administrador General', 'Libre');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
