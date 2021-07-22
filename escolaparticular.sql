-- phpMyAdmin SQL Dump
-- version 5.1.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 17-Abr-2021 às 16:47
-- Versão do servidor: 10.4.18-MariaDB
-- versão do PHP: 7.4.16

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `escolaparticular`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `notaaluno`
--

CREATE TABLE `notaaluno` (
  `Id` int(11) NOT NULL,
  `Materia` varchar(30) DEFAULT NULL,
  `Nota` double DEFAULT NULL,
  `IdAluno` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `notaaluno`
--

INSERT INTO `notaaluno` (`Id`, `Materia`, `Nota`, `IdAluno`) VALUES
(1, 'Português ', 7.3, 3),
(2, 'Matemática ', 6.3, 3),
(3, 'Português ', 8.4, 5),
(4, 'Matemática ', 7.8, 5),
(5, 'Ciências', 9.3, 5),
(6, 'História', 6.4, 5),
(7, 'Geografia ', 5.8, 5),
(8, 'Geografia ', 9.5, 3),
(9, 'Ciências', 7.9, 3),
(10, 'História', 8.2, 3);

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `Id` int(11) NOT NULL,
  `Nome` varchar(80) DEFAULT NULL,
  `Login` varchar(80) DEFAULT NULL,
  `Senha` varchar(30) DEFAULT NULL,
  `TipoUsuario` varchar(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Extraindo dados da tabela `usuario`
--

INSERT INTO `usuario` (`Id`, `Nome`, `Login`, `Senha`, `TipoUsuario`) VALUES
(1, 'José', 'jose@email.com', '123456', 'D'),
(2, 'Gabriel', 'gabriel@email.com', '654321', 'M'),
(3, 'Marcos', 'marcos@email.com', 'abcdef', 'A'),
(4, 'João', 'joao@email.com', 'qwerty', 'P'),
(5, 'Júlio', 'julio@email.com', '098765', 'A'),
(6, 'Osvaldo', 'osvaldo@email.com', 'poiuyt', 'P');

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `notaaluno`
--
ALTER TABLE `notaaluno`
  ADD PRIMARY KEY (`Id`),
  ADD KEY `IdAluno` (`IdAluno`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`Id`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `notaaluno`
--
ALTER TABLE `notaaluno`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `Id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `notaaluno`
--
ALTER TABLE `notaaluno`
  ADD CONSTRAINT `notaaluno_ibfk_1` FOREIGN KEY (`IdAluno`) REFERENCES `usuario` (`Id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
