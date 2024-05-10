import math


# Exercise 2.1:
def num_len(n: int):
    return int(math.log(n, 10) + 1)


# Exercise 2.2
def pythagorean_triplet_by_sum(sum: int):
    triplets = []
    t = 2
    for s in range(1, sum // 4):
        for t in range(s + 1, sum // 4, 2):
            a = 2 * s * t
            b = t ** 2 - s ** 2
            c = s ** 2 + t ** 2
            if a + b + c == sum and a ** 2 + b ** 2 == c ** 2:
                if a > b:
                    tmp = a
                    a = b
                    b = tmp
                triplets.append(f"{a} < {b} < {c} : {sum}")
    return triplets


# Exercise 2.3
def is_sorted_polyndrom(polyndrom: str):  # ignoring Upper/lower cases as questions does not specify
    last_int = -1
    last_chr_value = 0
    for chr in polyndrom[:len(polyndrom) // 2 + 1]:
        if chr.isalpha():
            if ord(chr) < last_chr_value:
                return False
            last_chr_value = ord(chr)
        else:
            if last_int > int(chr):
                return False
            last_int = int(chr)
    return True


def main():
    # check 2.1
    """print(num_len(1234))
    print(num_len(12345))
    print(num_len(123456))"""

    # check 2.2
    """for i in range(10, 300):
        print(pythagorean_triplet_by_sum(i))"""

    # check 2.3
    """print(is_sorted_polyndrom("12321"))
    print(is_sorted_polyndrom("132231"))
    print(is_sorted_polyndrom("abba"))
    print(is_sorted_polyndrom("cbbc"))"""


if __name__ == '__main__':
    main()
