import math


# Exercise 2.1:
def num_len(n: int):
    return int(math.log(n, 10) + 1)


def pythagorean_triplet_by_sum(sum: int):
    triplets = []
    t = 2
    for s in range(1, sum // 4):
        for t in range(s + 1, sum // 4, 2):
            a = 2 * s * t
            b = t**2 - s**2
            c = s**2 + t**2
            if a + b + c == sum and a**2 + b**2 == c**2:
                if a > b:
                    tmp = a
                    a = b
                    b = tmp
                triplets.append(f"{a} < {b} < {c} : {sum}")
    return triplets

def main():
    # check 2.1
    """print(num_len(1234))
    print(num_len(12345))
    print(num_len(123456))"""

    # check 2.2
    """for i in range(10, 300):
        print(pythagorean_triplet_by_sum(i))"""


if __name__ == '__main__':
    main()
