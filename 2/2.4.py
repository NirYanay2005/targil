import matplotlib.pyplot
import matplotlib.pyplot as plt


def addToArray(array, new_item):
    if len(array) == 0:
        array.append(new_item)
    else:
        if new_item < array[0]:
            array.insert(0, new_item)
        else:
            array.append(new_item)


def sort_numbers(array: list):
    if len(array) <= 1:
        return array
    else:
        pivot = array.pop()
    less_than_pivot = []
    more_than_pivot = []
    for i in array:
        if i < pivot:
            addToArray(less_than_pivot, i)
        else:
            addToArray(more_than_pivot, i)
    return sort_numbers(less_than_pivot) + [pivot] + sort_numbers(more_than_pivot)


def graph_numbers(numbers: list):
    sorted_numbers = sort_numbers(numbers)
    matplotlib.pyplot.scatter([i for i in range(len(numbers))], numbers,
                              color='red', label='numbers')
    for i, (xi, yi) in enumerate(zip([i for i in range(len(numbers))],
                                     numbers)):
        plt.annotate(f'({xi}, {yi})', (xi, yi), textcoords="offset points",
                     xytext=(10, 10), ha='center')
    plt.xlim(0, len(numbers) - 1)
    plt.grid(True)
    plt.show()


def main():
    numbers = []
    sum_of_numbers = 0
    num_of_positive = 0
    show_graph = 'N'
    while True:
        try:
            tmp = float(input("Please enter a number: "))
        except ValueError:
            print("Please enter a valid NUMBER!")
            continue
        if tmp == -1:
            break
        numbers.append(tmp)
        sum_of_numbers += tmp
        if tmp > 0:
            num_of_positive += 1

    print(f"Average = {sum_of_numbers / len(numbers)} || Number of positives\
     = {num_of_positive}")
    print(sort_numbers(numbers)) #  didnt know if i can use .sort
    show_graph = input("Do you want to see the numbers on a graph? (Y/N): ")
    if show_graph.lower() == 'y':
        graph_numbers(numbers)
    else:
        print("Your loss...")


if __name__ == "__main__":
    main()
