
<h1 align="center">
    <a href="https://laravelcollective.com/tools/banner">
        <img alt="Banner" title="#Banner" style="object-fit: cover; height:250px;" src="petpro_banner.png"  />
    </a>
</h1>

## Pet Pro - Ajudando seu Pet! 🐾 

Sistema que vai facilitar o agendamento de consultas de animais em veterinários.          

## Descrição          

O projeto Pet Pro visa virtualizar o ambiente veterinário criando um sistema que pode facilitar o agendamento de consultas para os animais de um usuário. 

➡️ Caso você seja um usuário, o sistema possibilitará para você uma visão ampla dos horários dísponíveis em determinado dia de seu veterinário favorito, 
tornando possível agendar seu pet sem a necessidade de ligações ou mais questões que impedem um agendamento rápido;

➡️ Caso você seja um veterinário, nosso sistema pobilitará que você visualize seus próximos clientes, em qual horário foi agendado, qual o tipo,
a raça, e a situação do paciente que vai ser analisado, em um programa de fácil acesso e visualização;

➡️ Caso você seja administrador, você poderá fazer a entrada, a retirada e alteração de veterinários e usuários do sistema;

➡️ E ainda assim, caso seja usuário você poderá entrar com um requisito emergencial, para situações mais graves que precisam de atendimento imediato.


## Motivo

Realizamos nosso projeto pensando em todos os donos de pet que já passaram por dificuldades ao agendar uma consulta de veterinário, por falta de organização,
disponibilidade, agilidade e entre outros nos agendamentos. Nosso sistema impede que esses problemas aconteçam e permite um ambiente de comunição mais agil,
seguro e rápido.h

## Histórias de Usuário

#### Usuário

👥 𝗖𝗼𝗺𝗼 dono(a) de pet, 𝗾𝘂𝗲𝗿𝗼 agendar uma consulta no veterinário 𝗽𝗮𝗿𝗮 um atendimento mais rápido;

👥 𝗖𝗼𝗺𝗼 dono(a) de pet, 𝗾𝘂𝗲𝗿𝗼 visualizar horários disponíveis 𝗽𝗮𝗿𝗮 um agendamento mais rápido;

#### Veterinário

👥 𝗖𝗼𝗺𝗼 veterinário, 𝗾𝘂𝗲𝗿𝗼 visualizar os pets agendados 𝗽𝗮𝗿𝗮 um atendimento rápido;

👥 𝗖𝗼𝗺𝗼 veterinário, 𝗾𝘂𝗲𝗿𝗼 visualizar quais são os pets em estado de emergência 𝗽𝗮𝗿𝗮 um atendimento justo;

#### Administrador

👥 𝗖𝗼𝗺𝗼 administrador, 𝗾𝘂𝗲𝗿𝗼 gerenciar os dados de veterinários e usuários 𝗽𝗮𝗿𝗮 um sistema funcional;


## Funcionalidades

#### Requisitos Funcionais
- [x] Administrador cadastrar pelo menos um veterinário favorito do usuário;
- [ ] Login / Logout ou cadastro manual do Usuário/Veterinário/Administrador
- [ ] Visualização pelo usuário do seu veterinário favorito, tais como seus horários disponíveis.
- [ ] Permitir ao usuário agendar seu pet dentro do horário disponível, e apenas no horário disponível, além de visualizar que seu pet está agendado;
- [ ] Permitir ao usuário alterar seus dados de Login;
- [ ] Permitir ao usuário o cancelamento de um consulta;
- [ ] Permitir a entrada do usuário como emergência;
- [ ] Possibilitar ao veterinário a visualização de quais são os pets (além de sua raça e situação médica) agendados nos horários não disponíveis ou os horários disponíveis;
- [ ] Possibilitar ao veterinário a visualização dos pets em estado emergencial, que precisam de mais atendimento;
- [ ] Possibilitar ao veterinário alterar os horários disponíveis, se preciso;
- [ ] Criar uma interface para o administrador que o possibilite fácil acesso aos usuários e aos veterinários.


#### Requisitos Não Funcionais
- [x] Acesso rápido por meio de arquivo instalador exe;
- [ ] Proteger contra acesso não autorizado.
- [ ] Criar um sistema que possibilite a segurança de dados, permitindo ao usuário e ao veterinário, e apenas eles, a alteração de dados importantes;
- [ ] Permitir confiabilidade do usuário com dados reais e contato direto com os veterinários;
- [ ] Ser compatível com o sistema operacional do Windows 10;
- [ ] Tentativa de conexão adequada e correta por meio do servidor xammp, ligando-a diretamente com o banco de dados sql;
- [ ] Estar conforme a Lei nº 13.709, de 14 de agosto de 2018, que visa a segurança de dados;
- [ ] Atenda as necessidades do usuário e do veterinário;

## 📌 Índice
<p align="center">    
  <a href="#logotipo-ou-banner"> Logotipo ou Banner </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;        
  <a href="#nome-do-projeto"> Nome do Projeto </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;          
  <a href="#descrição"> Descrição e motivação </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;  
  <a href="#visuais-e-telas"> Visuais e Telas </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;        
  <a href="#tecnologias">Tecnologias </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;        
  <a href="#instalação"> Instalação e Funcionalidades </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;        
  <a href="#uso"> Uso </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;        
  <a href="#status-do-projeto"> Status do projeto </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp; &nbsp;        
  <a href="#issues"> Issues </a>  &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;  
  <a href="#contribuições"> Contribuições </a> &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;        
  <a href="#autor-e-agradecimentos"> Autores e Agradecimentos </a>  &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;  
  <a href="#referências"> Referências </a>  &nbsp; &nbsp; &nbsp; | &nbsp; &nbsp; &nbsp;  
  <a href="#licença"> Licença </a>    
</p>

É  possível visualizar o MarkDown dentro do VS Code adicionando uma extensão:
<h1 align="center">
    <img alt="VSCode" title="#VSCode" style="object-fit: cover; height:300px;" src=".github/markdown.png"  />
</h1>


## Badges           

Status: Opcional

Em alguns READMEs, você pode ver pequenas imagens que transmitem metadados, como se todos os testes estão passando ou não para o projeto.  Você pode usar Shields para adicionar alguns ao seu README.  Muitos serviços também possuem instruções para adicionar um crachá.           

## 📸 Visuais e Telas 

Status: Obrigatório

Dependendo do que você está fazendo, pode ser uma boa ideia incluir capturas de tela ou até mesmo um vídeo (você verá frequentemente GIFs em vez de vídeos reais).   

A maneira mais segura de manter os arquivos é criar uma pasta screenshots, github, assets, resources ou nome que você quiser e deixar os arquivos nela. Se você usar um CDN de imagens ou gif pode funcionar mas corre o risco do quebrar o link algum dia.

-------------
### Imagem GIF
<p align="center">
  <img src=".github/Readmedemo.gif" alt="GIF" width="700px" />
</p>

## Tecnologias                                

Status: Obrigatório

| Dia | Descriçao | tecnologias |
|:---:|---------|:-----------:|
|  03/08  |Acelerando sua evolução| ![npm](https://img.shields.io/npm/v/react?color=black&label=React&logo=react)  ![npm](https://img.shields.io/npm/v/typescript?color=black&label=Typescript&logo=typescript&logoColor=blue) |
|  **05/08**  |**A escolha da stack**|    ![npm](https://img.shields.io/npm/v/axios?color=black&label=Axios&logo=insomnia&logoColor=purple)   ![npm](https://img.shields.io/npm/v/sqlite3?color=black&label=Sqlite3&logo=sqlite&logoColor=Blue)       |
|  **07/08**  |**A milha extra**|             |



## ⚙ Instalação   

Status: Obrigatório

Dentro de um determinado ecossistema, pode haver uma maneira comum de instalar coisas, como usar Yarn, NuGet ou Homebrew.  No entanto, considere a possibilidade de que quem está lendo seu README seja um novato e gostaria de mais orientação.  Listar etapas específicas ajuda a remover ambigüidades e faz com que as pessoas usem seu projeto o mais rápido possível.  Se ele for executado apenas em um contexto específico, como uma determinada versão de linguagem de programação ou sistema operacional ou tiver dependências que devem ser instaladas manualmente, adicione também uma subseção Requisitos.    

-------------
### Comandos para instalar no MAC

| Tecnologia | Versão | Comando para instalar |
|:----------|------|---------------------|
|NodeJS| 12.18.2| ``` brew install node ``` |
|Yarn  |  1.17.3 | ```npm install -g yarn``` |
|Expo  |  3.23.1 |  ```yarn add global expo-cli```|

## Uso           

Use exemplos liberalmente e mostre a saída esperada, se puder.  É útil ter embutido o menor exemplo de uso que você pode demonstrar, enquanto fornece links para exemplos mais sofisticados se eles forem muito longos para serem incluídos no README.    

-------------

### Characters             
----

~~Strikethrough~~ <s>Strikethrough (when enable html tag decode.)</s>
*Italic*      _Italic_
**Emphasis**  __Emphasis__
***Emphasis Italic*** ___Emphasis Italic___

Superscript: X<sub>2</sub>，Subscript: O<sup>2</sup>

### Code Blocks (Indented style)

### Inline code

`$ npm install marked`

Indented 4 spaces, like `<pre>` (Preformatted Text).

    <?php
        echo "Hello world!";
    ?>
    
Code Blocks (Preformatted text):

    | First Header  | Second Header |
    | ------------- | ------------- |
    | Content Cell  | Content Cell  |
    | Content Cell  | Content Cell  |

### HTML code

```html
<!DOCTYPE html>
<html>
    <head>
        <mate charest="utf-8" />
        <title>Hello world!</title>
    </head>
    <body>
        <h1>Hello world!</h1>
    </body>
</html>
```
### HTML entities

&copy; &  &uml; &trade; &iexcl; &pound;
&amp; &lt; &gt; &yen; &euro; &reg; &plusmn; &para; &sect; &brvbar; &macr; &laquo; &middot; 

X&sup2; Y&sup3; &frac34; &frac14;  &times;  &divide;   &raquo;

18&ordm;C  &quot;  &apos;

### Escaping for Special Characters

\*literal asterisks\*

### Clonagem

Primeiro, clone o repositório para seu ambiente:

```bash
> git clone https://github.com/shyoutarou/REPO_NAME.git 
```

Depois, entre no repositório clonado e no diretório correspondente ao que quer testar (web, server).
Logo após, insira os seguintes comandos no seu terminal para cada diretório respectivamente:

### 📦 Executar Server API REST

```bash
# Entra no diretório "REPO_NAME"
> cd ./REPO_NAME

# Instala todas as dependências
> yarn install or npm install

```
## Status do projeto    

Status: Opcional

Indica se o projeto está em desenvolvimento ou já foi concluído. Se você ficou sem energia ou tempo para o seu projeto, coloque uma nota no topo do README dizendo que o desenvolvimento foi desacelerado ou parou completamente.  Alguém pode escolher fazer um fork do seu projeto ou se voluntariar para entrar como mantenedor ou proprietário, permitindo que o projeto continue.  Você também pode fazer uma solicitação explícita para mantenedores.           

## 🐛 Issues

Status: Opcional

Ofereça às pessoas uma forma de contato.  Pode ser qualquer combinação de contatos, uma sala de chat, um endereço de e-mail, etc.   

-------------
> Sinta-se à vontade para registrar um novo problema com o respectivo título e descrição no repositório Proffy. 
> Se você já encontrou uma solução para seu problema, adoraria revisar sua solicitação de pull!

## 🤝 Contribuições    

Status: Obrigatório

Se você tiver ideias para lançamentos no futuro, é uma boa ideia listá-los no README.      Indique se você está aberto a contribuições e quais são seus requisitos para aceitá-las.           

Para as pessoas que desejam fazer alterações em seu projeto, é útil ter alguma documentação sobre como começar.  Talvez haja um script que eles devam executar ou algumas variáveis de ambiente que eles precisem definir.  Torne essas etapas explícitas.  Essas instruções também podem ser úteis para o seu futuro eu.           

Você também pode documentar comandos para lintar o código ou executar testes.  Essas etapas ajudam a garantir a alta qualidade do código e a reduzir a probabilidade de que as alterações quebrem algo inadvertidamente.  Ter instruções para a execução de testes é especialmente útil se requer configuração externa, como iniciar um servidor Selenium para testar em um navegador.      

-------------
Siga os passos abaixo para contribuir:

1. Faça o *fork* do projeto (<https://github.com/shyoutarou/REPO_NAME.git>)

2. Clone o seu *fork* para sua maquína (`git clone https://github.com/user_name/REPO_NAME.git`)

3. Crie uma *branch* para realizar sua modificação (`git checkout -b feature/name_new_feature`)

4. Adicione suas modificações e faça o *commit* (`git commit -m "Descreva sua modificação"`)

5. *Push* (`git push origin feature/name_new_feature`)

6. Crie um novo *Pull Request*

7. Pronto, agora só aguardar a análise 

## Autores e reconhecimento     

Status: Opcional

Mostre sua gratidão àqueles que contribuíram para o projeto.  

-------------
 <div align=center>
  <table style="width:100%">
    <tr align=center>
      <th><strong>Eu</strong></th>
    </tr>
    <tr align=center>
      <td>
        <a href="https://github.com/shyoutarou">
          <img width="200" height="180" style="border-radius: 50%;" src="https://avatars3.githubusercontent.com/u/66930143?s=460&u=9a46318c1563414a627c432d89b8ae53bf359430&v=4">
        </a>
      </td>
    </tr>
  </table>
</div> 
 
## ***Referências***

Status: Obrigatório

* Banner
    - [Laravel Collective](https://laravelcollective.com/tools/banner)

* MarkDown
    - [Editor.md](https://pandao.github.io/editor.md/en.html)
    - [Dillinger](https://dillinger.io/)
    - [Stackedit](https://stackedit.io/) 
    - [Devbaraus](https://github.com/devbaraus/markdown-showcase) 

* Badges
    - [Shields](https://shields.io/)
    - [How to Make Custom Badges](https://dev.to/milkers/how-to-make-custom-badges-to-improve-your-markdown-documents-460k)
    - [Badger](http://badges.github.io/badgerbadgerbadger/)

* GIFS
    - [Recordit](https://recordit.co/)
    - [ttystudio](https://github.com/chjj/ttystudio)

* Guias
    - [Como fazer um bom README](https://blog.rocketseat.com.br/como-fazer-um-bom-readme/)
    - [Make a README](https://www.makeareadme.com/)
    - [sampleREADME.md](https://gist.github.com/fvcproductions/1bfc2d4aecb01a834b46)





## 📜 Licença   

Status: Obrigatório

Para projetos de código aberto, diga como está licenciado.

-------------
O projeto publicado em 2020 sobre a licença [MIT](./LICENSE) ❤️ 

Made with ❤️ by Shyoutarou

Gostou? Deixe uma estrelinha para ajudar o projeto ⭐

- [Voltar ao Início](#index)
