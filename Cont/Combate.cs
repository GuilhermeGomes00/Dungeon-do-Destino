using System;
using Text_Game.Cont;

namespace Text_Game.Core
{
    public class Combate
    {
        private PersonagemBase jogador;
        private PersonagemBase inimigo;

        public Combate(PersonagemBase player, PersonagemBase mob)
        {
            jogador = player;
            inimigo = mob;
        }

        public void Iniciar()
        {
            while (jogador.IsLive() && inimigo.IsLive())
            {
                ExibirHUD();
                TurnoJogador();
                if (!inimigo.IsLive()) break;
                TurnoInimigo();
            }

            Console.WriteLine("\n=== FIM DO COMBATE ===");
            Console.WriteLine(jogador.IsLive() ? "Você venceu!" : "Você foi derrotado...");
        }

        private void ExibirHUD()
        {
            Console.Clear();
            Console.WriteLine("================ COMBATE ================");
            Console.WriteLine("\n--- IMG PLACEHOLDER ---\n");

            // ASCII Art Placeholder
            Console.WriteLine("⣿⣿⣿⠄⠄⣀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣿⣿⣿⣿");
            Console.WriteLine("⣿⣿⣿⠄⢠⡏⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⣿⣿⣿⣿");
            Console.WriteLine("⠙⠛⠛⠄⠾⢀⡀⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠄⠙⠛⠛⠛");
            Console.WriteLine("⣶⣦⣄⢀⣀⡀⠄⠉⠉⠁⠄⠄⠄⠄⠄⠄⠄⠄⠄⣀⡀⠄⣤⣤⣶⣶");
            Console.WriteLine("⣿⣿⠛⠸⣿⣿⣿⣿⣟⣿⣿⣿⣿⣿⣟⣻⣾⣿⣿⣿⡅⠄⢻⢿⣿⣿");
            Console.WriteLine("⣿⣧⡃⠄⢀⠤⠄⠄⠄⠄⠄⢀⡀⠄⢠⡤⠄⠄⠄⠄⠄⠄⡇⢠⣿⣿");
            Console.WriteLine("⣿⣿⡇⠄⢹⠄⠄⠄⠄⠄⠄⢸⣿⠄⠘⠄⠄⠄⠄⠄⠄⢸⢀⣿⣿⣿");
            Console.WriteLine("⣿⣿⡝⡇⢄⣀⣀⣀⣀⣠⣴⣸⣿⠄⠈⢀⠄⢀⣀⡀⠄⢨⣾⣿⣿⣿");
            Console.WriteLine("⣿⣿⣿⣅⠸⣿⣿⣿⣿⣹⡿⠿⡿⠇⠋⡻⣿⣿⠟⠄⠄⣦⣿⣿⣿⣿");
            Console.WriteLine("⣿⣿⣿⣿⠄⣿⡽⣿⠗⠋⠉⠁⠈⠄⠉⠘⠛⣿⢠⠄⠄⣿⣿⣿⣿⣿");
            Console.WriteLine("⣿⣿⣿⣿⣿⣷⣸⠄⢐⢿⡏⠁⠄⠈⢹⠿⠟⢀⣾⣾⣿⣿⣿⣿⣿⣿");

            Console.WriteLine($"\n{jogador.Nome} (HP: {jogador.HP}/{jogador.HP_MAX} | Mana: {(jogador is Mago m ? m.Mana : jogador is Arqueiro a ? a.Mana : 0)} | Poções: {jogador.QuantidadePocoes})");
            Console.WriteLine($"VS");
            Console.WriteLine($"{inimigo.Nome} (HP: {inimigo.HP}/{inimigo.HP_MAX})\n");
            Console.WriteLine("=========================================");
        }

        private void TurnoJogador()
        {
            bool turnoAtivo = true;
            while (turnoAtivo)
            {
                Console.WriteLine("1 - Atacar");
                Console.WriteLine("2 - Usar Poção");
                Console.WriteLine("3 - Fugir");
                if (jogador is Guerreiro) Console.WriteLine("4 - Usar Second Wind");
                if (jogador is Arqueiro) Console.WriteLine("4 - Sharp Shooter");
                if (jogador is Mago)
                {
                    Console.WriteLine("4 - Ray of Frost");
                    Console.WriteLine("5 - Freezing Touch");
                    Console.WriteLine("6 - Cyro Mortem");
                    Console.WriteLine("7 - Arcane Vitality");
                    Console.WriteLine("8 - Ice Shield");
                }

                Console.Write("Escolha uma ação: ");
                string? opcao = Console.ReadLine();
                Console.WriteLine();

                switch (opcao)
                {
                    case "1":
                        int dano = jogador.Arma?.Atacar(jogador.STR, inimigo.AC) ?? 0;
                        inimigo.ReceberDano(dano);
                        turnoAtivo = false;
                        break;
                    case "2":
                        jogador.UsarPocaoDeCura();
                        break;
                    case "3":
                        turnoAtivo = jogador.Fugir(15);
                        break;
                    case "4":
                        if (jogador is Guerreiro g)
                        {
                            g.secondWind();
                        }
                        else if (jogador is Arqueiro ar)
                        {
                            dano = ar.SharpShooterATTACK(ar.DEX, inimigo.AC);
                            inimigo.ReceberDano(dano);
                            turnoAtivo = false;
                        }
                        else if (jogador is Mago m)
                        {
                            dano = m.Arma is ArcaneStaff staff ? staff.AtacarROF(m.INT, inimigo.AC) : 0;
                            inimigo.ReceberDano(dano);
                            turnoAtivo = false;
                        }
                        break;
                    case "5":
                        if (jogador is Mago m1 && m1.Arma is ArcaneStaff st1)
                        {
                            dano = st1.AtacarFT(m1.INT, inimigo.AC);
                            inimigo.ReceberDano(dano);
                            turnoAtivo = false;
                        }
                        break;
                    case "6":
                        if (jogador is Mago m2 && m2.Arma is ArcaneStaff st2)
                        {
                            dano = st2.AtacarCM(inimigo.DEX, 14);
                            inimigo.ReceberDano(dano);
                            turnoAtivo = false;
                        }
                        break;
                    case "7":
                        if (jogador is Mago m3)
                        {
                            m3.ArcaneVitality();
                        }
                        break;
                    case "8":
                        if (jogador is Mago m4)
                        {
                            m4.IceShield();
                        }
                        break;
                    default:
                        Console.WriteLine("Opção inválida!");
                        break;
                }
                Console.WriteLine();
            }
        }

        private void TurnoInimigo()
        {
            Console.WriteLine("Turno do inimigo...");
            System.Threading.Thread.Sleep(1000);

            int dano = 0;
            if (inimigo is VoidSoul v)
            {
                int roll = Dice.Roll(1, 10);
                if (roll == 10)
                {
                    dano = v.PsychicScreamSAVE(jogador.BonusResistencia);
                }
                else
                {
                    dano = v.OldSpearATTACK(jogador.AC);
                }
            }
            else if (inimigo is SkeletonDragon d)
            {
                int roll = Dice.Roll(1, 12);
                if (roll == 12)
                {
                    dano = d.PutridBreathSAVE(jogador.BonusResistencia);
                }
                else if (roll <= 5)
                {
                    dano = d.ClawATTACK(jogador.AC);
                }
                else
                {
                    dano = d.BiteATTACK(jogador.AC);
                }
            }
            else if (inimigo is Zombie z)
            {
                dano = Dice.Roll(1, 2) == 1 ? z.ClawsATTACK(jogador.AC) : z.BiteATTACK(jogador.AC);
            }
            else if (inimigo is Skeleton sk)
            {
                dano = sk.SwordATTACK(jogador.AC);
            }
            else if (inimigo is Mimic m)
            {
                dano = Dice.Roll(1, 2) == 1 ? m.BiteATTACK(jogador.AC) : m.SlamATTACK(jogador.AC);
            }

            jogador.ReceberDano(dano);
            Console.WriteLine($"{jogador.Nome} Recebeu {dano} pontos de dano.");
            Console.WriteLine("Pressione Enter para continuar...");
            Console.ReadLine();
        }
    }
}
