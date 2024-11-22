-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 22-Nov-2024 às 13:38
-- Versão do servidor: 10.4.22-MariaDB
-- versão do PHP: 8.1.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `petpro`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `administrador`
--

CREATE TABLE `administrador` (
  `id_adm` int(11) NOT NULL,
  `nome_adm` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `animal`
--

CREATE TABLE `animal` (
  `id_animal` int(11) NOT NULL,
  `nome_animal` varchar(35) DEFAULT NULL,
  `tipo_animal` varchar(20) DEFAULT NULL,
  `raca_animal` varchar(35) DEFAULT NULL,
  `situacao_medica` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `animal_horario`
--

CREATE TABLE `animal_horario` (
  `FK_horario_id_horario` int(11) DEFAULT NULL,
  `FK_animal_id_animal` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `horario`
--

CREATE TABLE `horario` (
  `id_horario` int(11) NOT NULL,
  `data` varchar(13) DEFAULT NULL,
  `horario` varchar(6) DEFAULT NULL,
  `situacao` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL,
  `nome_usuario` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `telefone` varchar(13) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `veterinario`
--

CREATE TABLE `veterinario` (
  `id_veterinario` int(11) NOT NULL,
  `nome_veterinario` varchar(50) DEFAULT NULL,
  `telefone` varchar(13) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `veterinario_horario`
--

CREATE TABLE `veterinario_horario` (
  `FK_horario_id_horario` int(11) DEFAULT NULL,
  `FK_veterinario_id_veterinario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `administrador`
--
ALTER TABLE `administrador`
  ADD PRIMARY KEY (`id_adm`);

--
-- Índices para tabela `animal`
--
ALTER TABLE `animal`
  ADD PRIMARY KEY (`id_animal`);

--
-- Índices para tabela `animal_horario`
--
ALTER TABLE `animal_horario`
  ADD KEY `FK_animal_horario_0` (`FK_horario_id_horario`),
  ADD KEY `FK_animal_horario_1` (`FK_animal_id_animal`);

--
-- Índices para tabela `horario`
--
ALTER TABLE `horario`
  ADD PRIMARY KEY (`id_horario`);

--
-- Índices para tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id_usuario`);

--
-- Índices para tabela `veterinario`
--
ALTER TABLE `veterinario`
  ADD PRIMARY KEY (`id_veterinario`);

--
-- Índices para tabela `veterinario_horario`
--
ALTER TABLE `veterinario_horario`
  ADD KEY `FK_veterinario_horario_0` (`FK_horario_id_horario`),
  ADD KEY `FK_veterinario_horario_1` (`FK_veterinario_id_veterinario`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `animal_horario`
--
ALTER TABLE `animal_horario`
  ADD CONSTRAINT `FK_animal_horario_0` FOREIGN KEY (`FK_horario_id_horario`) REFERENCES `horario` (`id_horario`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_animal_horario_1` FOREIGN KEY (`FK_animal_id_animal`) REFERENCES `animal` (`id_animal`) ON DELETE SET NULL ON UPDATE CASCADE;

--
-- Limitadores para a tabela `veterinario_horario`
--
ALTER TABLE `veterinario_horario`
  ADD CONSTRAINT `FK_veterinario_horario_0` FOREIGN KEY (`FK_horario_id_horario`) REFERENCES `horario` (`id_horario`),
  ADD CONSTRAINT `FK_veterinario_horario_1` FOREIGN KEY (`FK_veterinario_id_veterinario`) REFERENCES `veterinario` (`id_veterinario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
