import math


def pythagorean_triplet_by_sum(sum: int):
    triplets = []
    for s in range(2, sum // 3):
        for t in range(1, s):
            if (s - t) % 2 == 1 and math.gcd(s, t) == 1:
                a = s ** 2 - t ** 2
                b = 2 * s * t
                c = s ** 2 + t ** 2
                if a + b + c > sum:
                    break
                if a + b + c == sum:
                    if a > b:
                        tmp = a
                        a = b
                        b = tmp
                    triplets.append((a, b, c))
    return triplets


def main():
    # check 2.2
    for i in range(10, 300):
        print(pythagorean_triplet_by_sum(i))


if __name__ == '__main__':
    main()
