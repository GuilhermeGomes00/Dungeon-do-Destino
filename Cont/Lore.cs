using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Text_Game.Core;

namespace Text_Game.Cont
{
    public static class Narrativa
    {
        public static PersonagemBase Jogador;
        public static void Introducao()
        {
            Console.Clear();
            Console.WriteLine("==================== DUNGEON DO DESTINO ====================\n");
            Console.WriteLine("Há muito tempo, um antigo santuário afundou sob a terra,");
            Console.WriteLine("engolido pelo tempo e pelos pecados de reis esquecidos.");
            Console.WriteLine("Dizem que esse lugar guarda um poder capaz de mudar o destino...\n");

            Console.WriteLine("Você acorda diante de um portão cravado em rochas negras,");
            Console.WriteLine("cercado por névoa e silêncio. Sua mente está nublada,");
            Console.WriteLine("mas um propósito pulsa forte em seu peito: **Entrar**.\n");

            Console.WriteLine("O ar é frio, o chão está coberto de ossos e ferro enferrujado.");
            Console.WriteLine("Cada passo que você dá ecoa como um aviso nos corredores vazios.\n");

            Console.WriteLine("Dizem que a Dungeon concede apenas duas escolhas:");
            Console.WriteLine("Glória... ou Morte.\n");

            Console.Write("Digite o nome do seu personagem: ");
            string nome = Console.ReadLine();

            Console.WriteLine("\nEscolha sua classe:");
            Console.WriteLine("1 - Guerreiro");
            Console.WriteLine("2 - Arqueiro");
            Console.WriteLine("3 - Mago");
            Console.Write("\nDigite o número da classe desejada: ");

            int escolhaClasse;
            while (!int.TryParse(Console.ReadLine(), out escolhaClasse) || escolhaClasse < 1 || escolhaClasse > 3)
            {
                Console.Write("Opção inválida. Escolha 1, 2 ou 3: ");
            }

            switch (escolhaClasse)
            {
                case 1:
                    Jogador = new Guerreiro(nome);
                    break;
                case 2:
                    Jogador = new Arqueiro(nome);
                    break;
                case 3:
                    Jogador = new Mago(nome);
                    break;
            }

            Console.WriteLine($"\nBem-vindo, {Jogador.CLASSE} {Jogador.Nome}!");
            Console.WriteLine("Aperte qualquer tecla para adentrar a dungeon...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Prologo()
        {
            while (Jogador.IsLive())
            {
                Console.Clear();

                Console.WriteLine("Você entra nos salões úmidos da Dungeon.");
                Console.WriteLine("O ar é denso, e o silêncio é perturbador.");
                Console.WriteLine("De repente, você ouve um som arrastado, acompanhado de um gemido gutural.\n");

                Console.WriteLine("Algo se aproxima pelas sombras...");
                Console.WriteLine("Prepare-se para seu primeiro desafio!\n");

                Console.WriteLine("Aperte qualquer tecla para enfrentar seu primeiro inimigo.");
                Console.ReadKey();

                Random rng = new Random();
                int escolha = rng.Next(0, 2); // 0 ou 1

                PersonagemBase inimigo;

                if (escolha == 0)
                {
                    inimigo = new Zombie("Zumbi Enfurecido");
                    Console.WriteLine("\nUm Zumbi cambaleante surge da escuridão, seus olhos vazios fixos em você.");
                }
                else
                {
                    inimigo = new Skeleton("Esqueleto Guerreiro");
                    Console.WriteLine("\nUm Esqueleto armado com um arco aparece, pronto para lhe causar dor.");
                }

                Console.WriteLine("\nCombate iniciado contra: " + inimigo.Nome);
                Console.WriteLine("Aperte qualquer tecla para continuar.");
                Console.ReadKey();

                Combate combate = new Combate(Jogador, inimigo);
                combate.Iniciar();
                break;
            }
        }

        public static void RiscoERecompensa()
        {
            while (Jogador.IsLive())
            {
                Console.Clear();

                Console.WriteLine("Após superar o primeiro combate, você encontra uma sala estranhamente silenciosa.");
                Console.WriteLine("No centro dela, repousa um baú antigo, coberto por poeira e musgo.\n");

                Console.WriteLine("Há rumores sobre baús vivos chamados Mímicos...");
                Console.WriteLine("Você sente o dilema: arriscar pela recompensa, ou ignorar e seguir seguro?\n");

                Console.Write("Deseja abrir o baú? (s/n): ");
                string resposta = Console.ReadLine().ToLower();

                if (resposta == "s")
                {
                    Random rng = new Random();
                    int chance = rng.Next(0, 100);

                    if (chance < 65)
                    {
                        Console.WriteLine("\nAssim que toca no baú, ele se contorce violentamente. Não é um baú... é um Mímico!");
                        PersonagemBase mimico = new Mimic("Mímico Faminto");
                        Console.WriteLine("Aperte qualquer tecla para combater o Mímico!");
                        Console.ReadKey();
                        Combate combate = new Combate(Jogador, mimico);
                        combate.Iniciar();
                    }
                    else
                    {
                        Console.WriteLine("\nVocê abre o baú cuidadosamente. Nada salta — parece seguro.");
                    }

                    Console.WriteLine("\nDentro do baú, você encontra um item raro!");
                    if (Jogador is Mago)
                    {
                        Console.WriteLine("Você encontra duas poções mágicas brilhantes. Elas podem restaurar sua energia vital.");
                        Jogador.QuantidadePocoes = +3;
                    }
                    else
                    {
                        Console.WriteLine("Você encontra uma espada reluzente, forjada com prata encantada.");
                        Jogador.Arma = new SunBlade();
                    }
                }
                else
                {
                    Console.WriteLine("\nVocê decide não arriscar. O baú permanece intocado enquanto você segue adiante.");
                }

                Console.WriteLine("\nAperte qualquer tecla para continuar sua jornada.");
                Console.ReadKey();
                break;
            }
        }

        public static void AlmaPerdida()
        {
            while (Jogador.IsLive())
            {

                Console.Clear();

                Console.WriteLine("Você caminha por um corredor coberto de símbolos antigos.");
                Console.WriteLine("Um sussurro gélido invade sua mente.\n");

                Console.WriteLine("Uma presença espectral se revela — uma Alma do Vazio,\natormentada por séculos de dor.\n");

                Console.WriteLine("Derrotá-la pode lhe conceder poções valiosas.\n");
                Console.WriteLine("Prepare-se para o combate mental e físico.\n");

                Console.WriteLine("Aperte qualquer tecla para confrontar a alma perdida.");
                Console.ReadKey();

                PersonagemBase alma = new VoidSoul("Alma do Vazio");
                Combate combate = new Combate(Jogador, alma);
                combate.Iniciar();

                Console.WriteLine("\nCom a alma derrotada, uma luz tênue envolve o ambiente.");
                Console.WriteLine("Você sente sua energia se renovar.");
                Console.WriteLine("Você encontrou 3 poções de cura.");
                Jogador.QuantidadePocoes += 3;

                Console.WriteLine("\nAperte qualquer tecla para seguir rumo ao destino final...");
                Console.ReadKey();
                break;
            }
        }

        public static void ChefeFinal()
        {
            while (Jogador.IsLive()) {
                Console.Clear();

                Console.WriteLine("O chão treme. As paredes ecoam com um rugido ancestral.\n");
                Console.WriteLine("Você adentra a câmara final da Dungeon, onde jaz o guardião supremo.\n");

                Console.WriteLine("De ossos e sombras, o Dragão Esqueleto desperta,\ncom olhos flamejantes e fôlego podre.\n");

                Console.WriteLine("Este é o seu destino. Esta é sua prova final.\n");
                Console.WriteLine("Prepare-se para o combate definitivo.\n");

                Console.WriteLine("Aperte qualquer tecla para enfrentar o Dragão Esqueleto.");
                Console.ReadKey();

                PersonagemBase chefe = new SkeletonDragon("Dragão Esqueleto");
                Combate combate = new Combate(Jogador, chefe);
                combate.Iniciar();

                Console.WriteLine("\nO Dragão ruge uma última vez antes de cair em pedaços.");
                Console.WriteLine("A Dungeon começa a tremer — você corre em direção à saída, sentindo o peso da vitória.");

                Console.WriteLine("\nParabéns! Você conquistou a Glória na Dungeon do Destino!");
                Console.WriteLine("Aperte qualquer tecla para encerrar sua jornada...");
                Console.ReadKey();
                break;
            }
        }
    }
}
