using System.Numerics;

namespace Day11
{
    internal class Monkey
    {
        internal static List<Monkey> All { get; } = new();

        internal int Id { get; init; }

        internal List<ulong> Items { get; init; }

        internal List<ulong> ItemsPart2 { get; init; }

        internal string Operation { get; set; }

        internal ulong TestDivisableBy { get; init; }

        internal int TestTrueId { get; init; }

        internal int TestFalseId { get; init; }

        internal ulong InspectedItems { get; set; }

        internal void ReceiveItem(ulong item)
        {
            Items.Add(item);
        }

        internal void ReceiveItemPart2(ulong item)
        {
            ItemsPart2.Add(item);
        }

        internal void ThrowItems()
        {
            foreach (var item in Items.ToArray().AsSpan())
            {
                InspectedItems++;
                SendItem(item);
                Items.Remove(item);
            }
        }

        internal void ThrowItemsPart2(ulong allDividedBy)
        {
            foreach (var item in ItemsPart2.ToArray().AsSpan())
            {
                InspectedItems++;
                SendItemPart2(item, allDividedBy);
                ItemsPart2.Remove(item);
            }
        }

        internal void SendItem(ulong item)
        {
            var result = 0uL;
            ReadOnlySpan<char> operationSpan = Operation;
            if (operationSpan.StartsWith("old"))
            {
                result = item;

                if (operationSpan[4] == '+')
                {
                    operationSpan = operationSpan[6..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result += item;
                    }
                    else
                    {
                        result += ulong.Parse(operationSpan);
                    }
                }
                else // *
                {
                    operationSpan = operationSpan[6..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result *= item;
                    }
                    else
                    {
                        result *= ulong.Parse(operationSpan);
                    }
                }
            }
            else
            {
                var multiIndex = operationSpan.IndexOf('*');
                var plusIndex = operationSpan.IndexOf('+');
                if (multiIndex != -1)
                {
                    result = ulong.Parse(operationSpan[..(multiIndex-1)]);


                    operationSpan = operationSpan[(multiIndex+1)..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result *= item;
                    }
                    else
                    {
                        result *= ulong.Parse(operationSpan);
                    }
                }
                else
                {
                    result = ulong.Parse(operationSpan[..(plusIndex - 1)]);


                    operationSpan = operationSpan[(multiIndex + 1)..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result += item;
                    }
                    else
                    {
                        result += ulong.Parse(operationSpan);
                    }
                }
            }

            result = (ulong)Math.Floor((double)result / 3);

            if (result % TestDivisableBy == 0)
            {
                All.Find(x => x.Id == TestTrueId).ReceiveItem(result);
            }
            else
            {
                All.Find(x => x.Id == TestFalseId).ReceiveItem(result);
            }
        }

        internal void SendItemPart2(ulong item, ulong allDividedBy)
        {
            var result = 0uL;
            ReadOnlySpan<char> operationSpan = Operation;
            if (operationSpan.StartsWith("old"))
            {
                result = item;

                if (operationSpan[4] == '+')
                {
                    operationSpan = operationSpan[6..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result += item;
                    }
                    else
                    {
                        result += ulong.Parse(operationSpan);
                    }
                }
                else // *
                {
                    operationSpan = operationSpan[6..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result *= item;
                    }
                    else
                    {
                        result *= ulong.Parse(operationSpan);
                    }
                }
            }
            else
            {
                var multiIndex = operationSpan.IndexOf('*');
                var plusIndex = operationSpan.IndexOf('+');
                if (multiIndex != -1)
                {
                    result = ulong.Parse(operationSpan[..(multiIndex - 1)]);


                    operationSpan = operationSpan[(multiIndex + 1)..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result *= item;
                    }
                    else
                    {
                        result *= ulong.Parse(operationSpan);
                    }
                }
                else
                {
                    result = ulong.Parse(operationSpan[..(plusIndex - 1)]);


                    operationSpan = operationSpan[(multiIndex + 1)..];
                    if (operationSpan.StartsWith("old"))
                    {
                        result += item;
                    }
                    else
                    {
                        result += ulong.Parse(operationSpan);
                    }
                }
            }

            var modifiedResult = result % allDividedBy;

            if (result % TestDivisableBy == 0)
            {
                All.Find(x => x.Id == TestTrueId).ReceiveItemPart2(modifiedResult);
            }
            else
            {
                All.Find(x => x.Id == TestFalseId).ReceiveItemPart2(modifiedResult);
            }
        }
    }
}
