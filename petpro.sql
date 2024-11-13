-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 04-Nov-2024 às 13:13
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
-- Estrutura da tabela `agendamento`
--

CREATE TABLE `agendamento` (
  `fk_horario_id_horario` int(11) DEFAULT NULL,
  `fk_animal_id_animal` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `animal`
--

CREATE TABLE `animal` (
  `id_animal` int(11) NOT NULL,
  `nome_animal` varchar(100) DEFAULT NULL,
  `tipo_animal` varchar(50) DEFAULT NULL,
  `raca` varchar(50) DEFAULT NULL,
  `situacao_medica` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `endereco`
--

CREATE TABLE `endereco` (
  `endereco_PK` int(11) NOT NULL,
  `bairro` varchar(50) DEFAULT NULL,
  `cidade` varchar(30) DEFAULT NULL,
  `numero` varchar(5) DEFAULT NULL,
  `rua` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `horario`
--

CREATE TABLE `horario` (
  `id_horario` int(11) NOT NULL,
  `data` date DEFAULT NULL,
  `horario` varchar(5) DEFAULT NULL,
  `situacao` varchar(7) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `usuario`
--

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL,
  `nome_usuario` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `telefone` varchar(14) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `veterinario`
--

CREATE TABLE `veterinario` (
  `id_veterinario` int(11) NOT NULL,
  `nome_veterinario` varchar(50) DEFAULT NULL,
  `fk_endereco_endereco_PK` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Estrutura da tabela `veterinario_horario`
--

CREATE TABLE `veterinario_horario` (
  `fk_veterinario_id_veterinario` int(11) DEFAULT NULL,
  `fk_horario_id_horario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `agendamento`
--
ALTER TABLE `agendamento`
  ADD KEY `FK_agendamento_0` (`fk_horario_id_horario`),
  ADD KEY `FK_agendamento_1` (`fk_animal_id_animal`);

--
-- Índices para tabela `animal`
--
ALTER TABLE `animal`
  ADD PRIMARY KEY (`id_animal`);

--
-- Índices para tabela `endereco`
--
ALTER TABLE `endereco`
  ADD PRIMARY KEY (`endereco_PK`);

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
  ADD PRIMARY KEY (`id_veterinario`),
  ADD KEY `FK_veterinario_1` (`fk_endereco_endereco_PK`);

--
-- Índices para tabela `veterinario_horario`
--
ALTER TABLE `veterinario_horario`
  ADD KEY `FK_veterinario_horario_0` (`fk_veterinario_id_veterinario`),
  ADD KEY `FK_veterinario_horario_1` (`fk_horario_id_horario`);

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `agendamento`
--
ALTER TABLE `agendamento`
  ADD CONSTRAINT `FK_agendamento_0` FOREIGN KEY (`fk_horario_id_horario`) REFERENCES `horario` (`id_horario`) ON DELETE SET NULL,
  ADD CONSTRAINT `FK_agendamento_1` FOREIGN KEY (`fk_animal_id_animal`) REFERENCES `animal` (`id_animal`) ON DELETE SET NULL;

--
-- Limitadores para a tabela `veterinario`
--
ALTER TABLE `veterinario`
  ADD CONSTRAINT `FK_veterinario_1` FOREIGN KEY (`fk_endereco_endereco_PK`) REFERENCES `endereco` (`endereco_PK`) ON DELETE SET NULL;

--
-- Limitadores para a tabela `veterinario_horario`
--
ALTER TABLE `veterinario_horario`
  ADD CONSTRAINT `FK_veterinario_horario_0` FOREIGN KEY (`fk_veterinario_id_veterinario`) REFERENCES `veterinario` (`id_veterinario`),
  ADD CONSTRAINT `FK_veterinario_horario_1` FOREIGN KEY (`fk_horario_id_horario`) REFERENCES `horario` (`id_horario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
