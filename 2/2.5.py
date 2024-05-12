import math


# I could not understand if you ment that I need to calculate pi by myself or not
def reverse_n_pi_digits(n: int):
    return (str(math.pi)[:n + 1])[::-1]


# Hope this is fine....
def reverse_n_pi_digits_with_pi_calc(n: int):
    pi = (math.asin(math.sqrt(1 - 0.5 ** 2)) + math.fabs(math.asin(0.5))) * 2
    return (str(pi)[:n + 1])[::-1]


def main():
    print(reverse_n_pi_digits(3))
    print(reverse_n_pi_digits_with_pi_calc(3))


if __name__ == "__main__":
    main()
