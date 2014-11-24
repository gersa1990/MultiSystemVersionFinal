-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Servidor: localhost
-- Tiempo de generación: 24-11-2014 a las 12:12:48
-- Versión del servidor: 5.5.24-log
-- Versión de PHP: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Base de datos: `bookstore`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `admins`
--

CREATE TABLE IF NOT EXISTS `admins` (
  `idAdmin` int(11) NOT NULL AUTO_INCREMENT,
  `nameAdmin` varchar(50) NOT NULL,
  `lastNameAdmin` varchar(100) NOT NULL,
  `userNameAdmin` varchar(30) NOT NULL,
  `passAdmin` varchar(30) NOT NULL,
  `typeAdmin` int(11) NOT NULL,
  `turnAdmin` varchar(50) NOT NULL,
  PRIMARY KEY (`idAdmin`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Volcado de datos para la tabla `admins`
--

INSERT INTO `admins` (`idAdmin`, `nameAdmin`, `lastNameAdmin`, `userNameAdmin`, `passAdmin`, `typeAdmin`, `turnAdmin`) VALUES
(1, 'administrador ', 'principal', 'adminLibrary', 'adminLibrary', 1, 'Todo el día'),
(2, 'Jose', 'Antonio Chavez', 'admin', 'admin', 2, 'Matutino'),
(3, 'administrador ', 'vespertino', 'adminLate', 'adminLate', 3, 'Vespertino'),
(4, '..', '..', 'adminGral', 'adminGral', 100, 'Libre'),
(5, 'asd', 'asd', 'asd', 'asd', 7, 'asd');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `books`
--

CREATE TABLE IF NOT EXISTS `books` (
  `idBook` int(11) NOT NULL AUTO_INCREMENT,
  `nameBook` varchar(100) NOT NULL,
  `author` varchar(100) NOT NULL,
  `editorial` varchar(50) NOT NULL,
  `edition` varchar(12) NOT NULL,
  `pages` int(30) DEFAULT NULL,
  `ISBN` varchar(10) DEFAULT NULL,
  `idGenere` int(11) NOT NULL,
  PRIMARY KEY (`idBook`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=23 ;

--
-- Volcado de datos para la tabla `books`
--

INSERT INTO `books` (`idBook`, `nameBook`, `author`, `editorial`, `edition`, `pages`, `ISBN`, `idGenere`) VALUES
(6, 'Bajo la misma estrella Jose', 'John Green 2', 'Nube de tinta', '2a', 1, '0-525-4788', 2),
(20, 'Shakespeare 2', 'asd', 'asd', 'asd', 0, 'Shakespear', 0),
(21, 'Ender', '132234234', 'Mac Millan', 'fgh', 120, '4564564564', 0),
(22, 'Libro Esmeralda', 'Shakespeare', 'Mac Millan', 'Tercera Edic', 1, '456565656', 0);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `generesbook`
--

CREATE TABLE IF NOT EXISTS `generesbook` (
  `idGenereBook` int(11) NOT NULL AUTO_INCREMENT,
  `nameGenereBook` varchar(100) NOT NULL,
  `descriptionGenereBook` varchar(100) NOT NULL,
  PRIMARY KEY (`idGenereBook`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=5 ;

--
-- Volcado de datos para la tabla `generesbook`
--

INSERT INTO `generesbook` (`idGenereBook`, `nameGenereBook`, `descriptionGenereBook`) VALUES
(1, 'Pediatria', 'asd'),
(2, 'Otra categoria ', 'ASD'),
(3, 'Ororrino loaringologia', 'asdasd'),
(4, 'Podologos', 'asdasdas');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `loansbook`
--

CREATE TABLE IF NOT EXISTS `loansbook` (
  `idLoan` int(11) NOT NULL AUTO_INCREMENT,
  `idBook` int(11) NOT NULL,
  `hashLoan` varchar(50) NOT NULL,
  `petitionDay` varchar(10) NOT NULL,
  `nameReader` varchar(100) NOT NULL,
  `hourLoan` varchar(5) NOT NULL,
  `hourDeliveryLoan` varchar(5) NOT NULL,
  `dateLoan` varchar(10) NOT NULL,
  `dateDeliveryLoan` varchar(10) NOT NULL,
  PRIMARY KEY (`idLoan`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=61 ;

--
-- Volcado de datos para la tabla `loansbook`
--

INSERT INTO `loansbook` (`idLoan`, `idBook`, `hashLoan`, `petitionDay`, `nameReader`, `hourLoan`, `hourDeliveryLoan`, `dateLoan`, `dateDeliveryLoan`) VALUES
(19, 21, '201474424340', '2014-07-29', 'Kiler pollo', '14:45', '02 MI', '2014-07-29', '2014-07-29'),
(20, 21, '201472344923', '2014-07-29', 'dfg', '15:24', '02 MI', '0000-00-00', '0000-00-00'),
(21, 21, '20147546618', '2014-07-29', 'gersa tes', '02:06', '02 MI', '0000-00-00', '2014-07-29'),
(22, 20, '2014763375', '2014-07-29', 'gersa siguiente día', '02:06', '02:07', '2014-07-29', '2014-07-29'),
(23, 21, '20147832624', '2014-07-29', 'test 1', '02:09', '02:08', '0000-00-00', '2014-07-29'),
(24, 6, '20147839973', '2014-07-29', 'test siguiente', '02:09', '02:09', '0000-00-00', '2014-07-29'),
(25, 21, '201471321915', '2014-07-29', 'test mismo día', '02:14', '02:13', '0000-00-00', '2014-07-29'),
(26, 6, '201471331487', '2014-07-29', 'test siguinte día', '02:14', '02:13', '2014-07-29', '2014-07-29'),
(27, 21, '20147156730', '2014-07-29', 'dfg', '02:16', '02:15', '2014-07-29', '2014-07-29'),
(28, 20, '201471511369', '2014-07-29', 'dfgdfgdfg', '02:16', '02:15', '2014-07-29', '2014-07-29'),
(29, 6, '201471518365', '2014-07-29', 'ftfghfghfgh', '02:16', '02:15', '2014-07-29', '2014-07-29'),
(30, 20, '201471541683', '2014-07-29', 'ftfghfghfgh', '02:16', '02:15', '0000-00-00', '2014-07-29'),
(31, 21, '201471544871', '2014-07-29', 'ftfghfghfgh', '02:16', '02:16', '0000-00-00', '2014-07-29'),
(32, 20, '201471549364', '2014-07-29', 'ftfghfghfgh', '02:16', '02:16', '0000-00-00', '2014-07-29'),
(33, 6, '201471651747', '2014-07-29', 'gsdfsdf', '02:17', '02:17', '0000-00-00', '2014-07-29'),
(34, 6, '201471653885', '2014-07-29', 'gsdfsdf', '02:17', '02:17', '2014-07-29', '2014-07-29'),
(35, 6, '201471655617', '2014-07-29', 'gsdfsdf', '02:17', '02:17', '2014-07-29', '2014-07-29'),
(36, 21, '201471658487', '2014-07-29', 'gsdfsdf', '02:17', '02:17', '2014-07-29', '2014-07-29'),
(37, 20, '20147170859', '2014-07-29', 'gsdfsdf', '02:17', '02:17', '2014-07-29', '2014-07-29'),
(38, 21, '201471716913', '2014-07-29', 'g', '02:18', '02:17', '2014-07-29', '2014-07-29'),
(39, 20, '20147172667', '2014-07-29', 'g', '02:18', '02:17', '2014-07-29', '2014-07-29'),
(40, 21, '20147203773', '2014-07-29', 'dfg', '02:21', '02:21', '0000-00-00', '2014-07-29'),
(41, 21, '201472038836', '2014-07-29', 'dfg', '02:21', '02:21', '2014-07-29', '2014-07-29'),
(42, 21, '201472156593', '2014-07-29', 'dfg', '02:22', '02:22', '2014-07-29', '2014-07-29'),
(43, 6, '201472249407', '2014-07-29', 'dfg', '02:23', '02:24', '0000-00-00', '2014-07-29'),
(44, 21, '201472510327', '2014-07-29', 'fxg', '02:25', '02:26', '0000-00-00', '2014-07-29'),
(45, 21, '201472512995', '2014-07-29', 'fxg', '02:25', '02:26', '2014-07-29', '2014-07-29'),
(46, 20, '201472622226', '2014-07-29', 'df', '02:26', '02:27', '2014-07-29', '2014-07-29'),
(47, 20, '201472625565', '2014-07-29', 'df', '02:26', '02:27', '0000-00-00', '2014-07-29'),
(48, 6, '201472712933', '2014-07-29', 'sdf', '02:27', '02:27', '2014-07-29', '2014-07-29'),
(49, 20, '201472833474', '2014-07-29', 'f', '02:29', '02:29', '2014-07-29', '2014-07-29'),
(50, 6, '201472931504', '2014-07-29', 'rt', '02:30', '02:30', '0000-00-00', '2014-07-29'),
(51, 6, '201472945452', '2014-07-29', 'dfgdfgdfg', '02:30', '02:30', '2014-07-29', '2014-07-29'),
(52, 6, '20147409906', '2014-07-29', 'sdfdfgdfgdfgdfdfg', '03:39', '03:40', '2014-07-29', '2014-07-29'),
(53, 6, '20148741687', '2014-08-02', 'zdfd', '18:06', '20:24', '2014-08-02', '2014-10-03'),
(54, 6, '2014828', '2014-08-02', 'd', '18:29', '20:24', '0000-00-00', '2014-10-03'),
(55, 21, '2014933', '2014-09-09', 'JOSE ANTONIO', '17:28', '00:00', '2014-09-09', '0000-00-00'),
(56, 20, '2014935', '2014-09-09', 'Angel', '17:28', '21:40', '0000-00-00', '2014-09-09'),
(57, 22, '20141018', '2014-10-03', 'TEST', '20:17', '00:00', '0000-00-00', '0000-00-00'),
(58, 6, '20141024', '2014-10-03', 'asd', '20:24', '20:25', '2014-10-03', '2014-10-03'),
(59, 20, '2014103526', '2014-10-08', 'pepe', '23:36', '00:00', '2014-10-08', '0000-00-00'),
(60, 6, '2014112352', '2014-11-09', 'gersa', '23:24', '00:00', '0000-00-00', '0000-00-00');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `typesadmin`
--

CREATE TABLE IF NOT EXISTS `typesadmin` (
  `idTypeAdmin` int(11) NOT NULL AUTO_INCREMENT,
  `descriptionAdmin` varchar(50) NOT NULL,
  PRIMARY KEY (`idTypeAdmin`)
) ENGINE=InnoDB  DEFAULT CHARSET=latin1 AUTO_INCREMENT=101 ;

--
-- Volcado de datos para la tabla `typesadmin`
--

INSERT INTO `typesadmin` (`idTypeAdmin`, `descriptionAdmin`) VALUES
(1, 'Administrador principal'),
(2, 'Administrador turno matutino'),
(3, 'Administrador turno vespertino'),
(4, 'Administrador turno nocturno 1'),
(5, 'Administrador turno nocturno 2'),
(6, 'Jornada acumulada 1'),
(7, 'Jornada Acumulada 2'),
(100, 'Administrador general');

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
