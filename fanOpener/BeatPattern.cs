using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
        public class BeatPattern
        {
            private int[,] Generate_Pattern(int[,] pattern)
            {
                Random randNum = new Random();
                Array.Clear(pattern, 0, pattern.Length);
                for (int i = 0; i <= 3; i++)
                {
                    pattern[i, 0] = randNum.Next(1, patOptions);
                    pattern[i, 1] = randNum.Next(1, 2);
                }
                //PrintArray(pattern);
                return pattern;
            }
            private void PlayPattern(int[,] pattern)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i, 1] == 1)
                    {
                        switch (pattern[i, 0])
                        {
                            case 1:
                                WingFlap(shortFlap, left);
                                break;
                            case 2:
                                WingFlap(medFlap, left);
                                break;
                            case 3:
                                WingFlap(longFlap, left);
                                break;
                            default:
                                break;
                        }

                    }
                    if (pattern[i, 1] == 2)
                    {
                        switch (pattern[i, 0])
                        {
                            case 1:
                                WingFlap(shortFlap, right);
                                break;
                            case 2:
                                WingFlap(medFlap, right);
                                break;
                            case 3:
                                WingFlap(longFlap, right);
                                break;
                            default:
                                break;
                        }
                    }
                    if (pattern[i, 1] == 3)
                    {
                        switch (pattern[i, 0])
                        {
                            case 1:
                                WingFlap(shortFlap, both);
                                break;
                            case 2:
                                WingFlap(medFlap, both);
                                break;
                            case 3:
                                WingFlap(longFlap, both);
                                break;
                            default:
                                break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }

            }
        }
}
