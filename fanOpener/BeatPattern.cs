using System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace fanOpener
{
        public class BeatPattern
        {
        //TODO: Figure out how to make it so that beatPattern does not require inherriting the enum from cicada.
        public int[,] Pattern { get; set; } = new int[8, 2] { { 1, 2 }, { 2, 1 }, { 1, 2 }, { 2, 2 }, { 1, 2 }, { 1, 1 }, { 2, 2 }, { 1, 2 } };

        public int patOptions = 2;
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
            private void PlayPattern(Wing Left, Wing Right, int[,] pattern)
            {
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i, 1] == 1)
                {
                    switch (pattern[i, 0])
                    {
                        case 1:
                            Left.flap(Wing.shortF);
                            break;
                        case 2:
                            Left.flap(Wing.mediumF);
                            break;
                        case 3:
                            Left.flap(Wing.longF);
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
                            Right.flap(Wing.shortF);
                            break;
                        case 2:
                            Right.flap(Wing.mediumF);
                            break;
                        case 3:
                            Right.flap(Wing.longF);
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
                                Right.flap(Wing.shortF);
                                Left.flap(Wing.shortF);
                                break;
                            case 2:
                                Right.flap(Wing.mediumF);
                                Left.flap(Wing.mediumF);
                                break;
                            case 3:
                                Right.flap(Wing.longF);
                                Left.flap(Wing.longF);
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
