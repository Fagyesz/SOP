-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1:3306
-- Létrehozás ideje: 2020. Dec 24. 20:53
-- Kiszolgáló verziója: 8.0.21
-- PHP verzió: 7.3.21

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `allatok`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `allatok`
--

DROP TABLE IF EXISTS `allatok`;
CREATE TABLE IF NOT EXISTS `allatok` (
  `id` int NOT NULL AUTO_INCREMENT,
  `name` varchar(100) NOT NULL,
  `classs` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci NOT NULL,
  `lovewinter` tinyint(1) NOT NULL,
  `lovechrismas` tinyint(1) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=74 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

--
-- A tábla adatainak kiíratása `allatok`
--

INSERT INTO `allatok` (`id`, `name`, `classs`, `lovewinter`, `lovechrismas`) VALUES
(1, 'kutya', 'emlos', 1, 1),
(2, 'macska', 'emlos', 0, 1),
(5, 'csiga', 'gyürüsfereg', 0, 0),
(6, 'zsiraf', 'emlos', 0, 0),
(68, 'őz', 'emlős', 0, 0),
(73, 'jegesmedve', 'jegesmedve', 1, 1),
(72, 'gólya', 'madár', 1, 1),
(71, 'nyúl', 'emlős', 1, 1),
(70, 'béka', 'hüllő', 0, 0),
(69, 'krokodil', 'hüllő', 0, 1),
(67, 'papagáj', 'madár', 0, 0),
(66, 'szúnyog', 'rovar', 0, 0),
(65, 'katicabogár', 'rovar', 0, 1),
(64, 'méhecske', 'rovar', 0, 1),
(63, 'tyúk', 'madár', 1, 0),
(62, 'pingvin', 'madár', 1, 1),
(61, 'hópárduc', 'emlős', 1, 1),
(60, 'pisztáng', 'hal', 1, 0),
(59, 'tasmánördög', 'emlős', 0, 1);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
