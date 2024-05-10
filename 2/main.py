import math


def num_len(n: int):
    return int(math.log(n, 10) + 1)


def main():
    print(num_len(1234))
    print(num_len(12345))
    print(num_len(123456))


if __name__ == '__main__':
    main()
