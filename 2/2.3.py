# ignoring Upper/lower cases as questions does not specify
def is_sorted_polyndrom(polyndrom: str):
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
    print(is_sorted_polyndrom("12321"))
    print(is_sorted_polyndrom("132231"))
    print(is_sorted_polyndrom("abba"))
    print(is_sorted_polyndrom("cbbc"))


if __name__ == '__main__':
    main()


"""
NOT A GREAT SOLUTION!!!!!!!!!!!
***********************************************************************************************************************************
***********************************************************************************************************************************
***********************************************************************************************************************************
***********************************************************************************************************************************
"""