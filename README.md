# MC2PCardManager
Gerenciamento e atualização para cartões do Multicore 2 e 2+

Programinha para ajudar a montar cartões SD com cores (e suas ROMS/disquetes quando for o caso)

Ainda é uma versão de teste mas já dá pra brincar.

Foi feito no .NET Framowork 4.7.2 inicialmente só para Windows e deveria rodar em versões de 32 ou 64 bits mas só testei no Windows 10 64 bits por enquanto.

Pra funcionar a configuração é simples. O programa pede:
  1) O diretório local do repositório do multicore (caso você não tenha baixado pra sua máquina, só escolher o local que o próprio programa baixa depois);
  2) O modelo do multicore;
  3) O cartão SD conectado que deverá ser usado;
  
 A interface só tem 5 botões:
  1) "..." em "Caminho reposítório: Abre o diálogo para escolher o diretório onde está (ou ficará) o repositório do Multicore do GitLab.
  2) "Salvar config": Salva as configurações (diretório local do repositório, drive do SD, modelo do multicore e os diretórios de ROMs).
  3) "Atualizar" em "Drive do cartão SD": Caso conecte o cartão SD depois de iniciar o programa, recarrega a lista de drives removíveis.
  4) "Diretórios de ROMs": Abre a tela de configuração dos caminhos locais para ROMs dos cores que as utilizam (Consoles e Computadores).
  5) "Verificar atualização no GitLab": Atualmente ele baixa a versão mais recente do repositório do Multicore no GitLab e atualiza o repositório local.
  
 Para incluir/excluir cores e ROMs (quando for o caso) basta ligar/desligar os "quadradinhos" nas arvores de cores (lado esquerdo) e ROMs (lado direito).
 Ligou o quadradinho, copia pro SD... Desligou o quadradinho, apaga do SD... Simples assim.
 
 Tem bastante coisa pra melhorar ainda, mas já faz o que deveria pra maioria dos usuários.
