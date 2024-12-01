-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 01/12/2024 às 03:28
-- Versão do servidor: 10.4.32-MariaDB
-- Versão do PHP: 8.1.25

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
-- Estrutura para tabela `administrador`
--

CREATE TABLE `administrador` (
  `id_adm` int(11) NOT NULL,
  `nome_adm` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `administrador`
--

INSERT INTO `administrador` (`id_adm`, `nome_adm`, `email`, `senha`, `permissao`) VALUES
(1, 'Pedro Amalfi', 'pedro@gmail.com', '1234', 'adm');

-- --------------------------------------------------------

--
-- Estrutura stand-in para view `agendamento_animais`
-- (Veja abaixo para a visão atual)
--
CREATE TABLE `agendamento_animais` (
`horario` varchar(6)
,`codigo` int(11)
,`nome_animal` varchar(35)
,`tipo_animal` varchar(20)
,`raca_animal` varchar(35)
,`situacao_medica` varchar(35)
);

-- --------------------------------------------------------

--
-- Estrutura para tabela `animal`
--

CREATE TABLE `animal` (
  `id_animal` int(11) NOT NULL,
  `nome_animal` varchar(35) DEFAULT NULL,
  `tipo_animal` varchar(20) DEFAULT NULL,
  `raca_animal` varchar(35) DEFAULT NULL,
  `situacao_medica` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `animal`
--

INSERT INTO `animal` (`id_animal`, `nome_animal`, `tipo_animal`, `raca_animal`, `situacao_medica`) VALUES
(4, 'Florentina', 'Pomba', 'Doméstico', 'Outro'),
(6, 'Percy', 'Porquinho da India', 'Americano', 'Outro'),
(8, 'Neguinho', 'Cão', 'Vira Lata', 'Fraco'),
(9, 'Bob', 'Cão', 'Pastor Alemão', 'Castrar');

-- --------------------------------------------------------

--
-- Estrutura para tabela `animal_horario`
--

CREATE TABLE `animal_horario` (
  `FK_horario_id_horario` int(11) DEFAULT NULL,
  `FK_animal_id_animal` int(11) DEFAULT NULL,
  `codigo` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `animal_horario`
--

INSERT INTO `animal_horario` (`FK_horario_id_horario`, `FK_animal_id_animal`, `codigo`) VALUES
(8, 4, ''),
(2, 8, '3431');

--
-- Acionadores `animal_horario`
--
DELIMITER $$
CREATE TRIGGER `after_delete_animal_horario` AFTER DELETE ON `animal_horario` FOR EACH ROW BEGIN
    -- Atualiza a situação do horário para "livre"
    UPDATE horario
    SET situacao = 'livre'
    WHERE id_horario = OLD.FK_horario_id_horario;
END
$$
DELIMITER ;
DELIMITER $$
CREATE TRIGGER `after_insert_animal_horario` AFTER INSERT ON `animal_horario` FOR EACH ROW BEGIN
    -- Atualiza a situação do horário para "ocupado"
    UPDATE horario
    SET situacao = 'ocupado'
    WHERE id_horario = NEW.FK_horario_id_horario;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura para tabela `emergencia`
--

CREATE TABLE `emergencia` (
  `id_emergencia` int(11) NOT NULL,
  `data_emergencia` varchar(50) DEFAULT NULL,
  `localizacao` varchar(120) NOT NULL,
  `codigo` varchar(4) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `emergencia`
--

INSERT INTO `emergencia` (`id_emergencia`, `data_emergencia`, `localizacao`, `codigo`) VALUES
(6, '30/11/2024 22:03:44', 'Mogi Guacu', '8754'),
(7, '30/11/2024 22:08:12', 'Mogi Guaçu', '5755');

-- --------------------------------------------------------

--
-- Estrutura para tabela `horario`
--

CREATE TABLE `horario` (
  `id_horario` int(11) NOT NULL,
  `data` varchar(13) DEFAULT NULL,
  `horario` varchar(6) DEFAULT NULL,
  `situacao` varchar(35) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `horario`
--

INSERT INTO `horario` (`id_horario`, `data`, `horario`, `situacao`) VALUES
(1, '25/11/2024', '09:00', 'livre'),
(2, '25/11/2024', '10:00', 'ocupado'),
(3, '25/11/2024', '11:00', 'livre'),
(4, '25/11/2024', '12:00', 'livre'),
(5, '25/11/2024', '13:00', 'livre'),
(6, '25/11/2024', '14:00', 'livre'),
(7, '25/11/2024', '15:00', 'livre'),
(8, '25/11/2024', '16:00', 'ocupado'),
(9, '25/11/2024', '17:00', 'livre');

-- --------------------------------------------------------

--
-- Estrutura para tabela `usuario`
--

CREATE TABLE `usuario` (
  `id_usuario` int(11) NOT NULL,
  `nome_usuario` varchar(50) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `telefone` varchar(13) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL,
  `img` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `usuario`
--

INSERT INTO `usuario` (`id_usuario`, `nome_usuario`, `email`, `telefone`, `senha`, `permissao`, `img`) VALUES
(2, 'mayra', 'mayra@gmail.com', '12345678', '1234', 'usr', '');

-- --------------------------------------------------------

--
-- Estrutura para tabela `veterinario`
--

CREATE TABLE `veterinario` (
  `id_veterinario` int(11) NOT NULL,
  `nome_veterinario` varchar(50) DEFAULT NULL,
  `localizacao` varchar(120) NOT NULL,
  `telefone` varchar(13) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `senha` varchar(8) DEFAULT NULL,
  `permissao` varchar(3) DEFAULT NULL,
  `img` blob NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `veterinario`
--

INSERT INTO `veterinario` (`id_veterinario`, `nome_veterinario`, `localizacao`, `telefone`, `email`, `senha`, `permissao`, `img`) VALUES
(5, 'Universo Pet', 'Mogi Guaçu', '12345678', 'universo@gmail.com', '1234', 'vet', ''),
(6, 'Centro Veterinario', 'Mogi Guaçu', '12345678', 'centro@gmail.com', '1234', 'vet', '');

--
-- Acionadores `veterinario`
--
DELIMITER $$
CREATE TRIGGER `after_veterinario_insert` AFTER INSERT ON `veterinario` FOR EACH ROW BEGIN
    INSERT INTO veterinario_horario (FK_horario_id_horario, FK_veterinario_id_veterinario)
    SELECT id_horario, NEW.id_veterinario
    FROM horario;
END
$$
DELIMITER ;

-- --------------------------------------------------------

--
-- Estrutura para tabela `veterinario_horario`
--

CREATE TABLE `veterinario_horario` (
  `FK_horario_id_horario` int(11) DEFAULT NULL,
  `FK_veterinario_id_veterinario` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Despejando dados para a tabela `veterinario_horario`
--

INSERT INTO `veterinario_horario` (`FK_horario_id_horario`, `FK_veterinario_id_veterinario`) VALUES
(1, 5),
(2, 5),
(3, 5),
(4, 5),
(5, 5),
(6, 5),
(7, 5),
(8, 5),
(9, 5),
(1, 6),
(2, 6),
(3, 6),
(4, 6),
(5, 6),
(6, 6),
(7, 6),
(8, 6),
(9, 6);

-- --------------------------------------------------------

--
-- Estrutura para view `agendamento_animais`
--
DROP TABLE IF EXISTS `agendamento_animais`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `agendamento_animais`  AS SELECT `horario`.`horario` AS `horario`, `animal`.`id_animal` AS `codigo`, `animal`.`nome_animal` AS `nome_animal`, `animal`.`tipo_animal` AS `tipo_animal`, `animal`.`raca_animal` AS `raca_animal`, `animal`.`situacao_medica` AS `situacao_medica` FROM ((`horario` left join `animal_horario` on(`horario`.`id_horario` = `animal_horario`.`FK_horario_id_horario`)) left join `animal` on(`animal_horario`.`FK_animal_id_animal` = `animal`.`id_animal`)) ORDER BY `horario`.`horario` ASC ;

--
-- Índices para tabelas despejadas
--

--
-- Índices de tabela `administrador`
--
ALTER TABLE `administrador`
  ADD PRIMARY KEY (`id_adm`);

--
-- Índices de tabela `animal`
--
ALTER TABLE `animal`
  ADD PRIMARY KEY (`id_animal`);

--
-- Índices de tabela `animal_horario`
--
ALTER TABLE `animal_horario`
  ADD KEY `FK_animal_horario_0` (`FK_horario_id_horario`),
  ADD KEY `FK_animal_horario_1` (`FK_animal_id_animal`);

--
-- Índices de tabela `emergencia`
--
ALTER TABLE `emergencia`
  ADD PRIMARY KEY (`id_emergencia`);

--
-- Índices de tabela `horario`
--
ALTER TABLE `horario`
  ADD PRIMARY KEY (`id_horario`);

--
-- Índices de tabela `usuario`
--
ALTER TABLE `usuario`
  ADD PRIMARY KEY (`id_usuario`);

--
-- Índices de tabela `veterinario`
--
ALTER TABLE `veterinario`
  ADD PRIMARY KEY (`id_veterinario`);

--
-- AUTO_INCREMENT para tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `administrador`
--
ALTER TABLE `administrador`
  MODIFY `id_adm` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `animal`
--
ALTER TABLE `animal`
  MODIFY `id_animal` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `emergencia`
--
ALTER TABLE `emergencia`
  MODIFY `id_emergencia` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT de tabela `horario`
--
ALTER TABLE `horario`
  MODIFY `id_horario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT de tabela `usuario`
--
ALTER TABLE `usuario`
  MODIFY `id_usuario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `veterinario`
--
ALTER TABLE `veterinario`
  MODIFY `id_veterinario` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Restrições para tabelas despejadas
--

--
-- Restrições para tabelas `animal_horario`
--
ALTER TABLE `animal_horario`
  ADD CONSTRAINT `FK_animal_horario_0` FOREIGN KEY (`FK_horario_id_horario`) REFERENCES `horario` (`id_horario`) ON DELETE SET NULL ON UPDATE CASCADE,
  ADD CONSTRAINT `FK_animal_horario_1` FOREIGN KEY (`FK_animal_id_animal`) REFERENCES `animal` (`id_animal`) ON DELETE SET NULL ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
