def date_and_time(file):
    counter = 0
    bits = ""
    numbers = []

    f = open(file, "r+")
    lines = f.readlines()
    for line in lines:
        if counter > 0:
            line = line[0: 29:] + line[len(line) + 1::]
            line = line.replace(
                '-', '').replace('T', '').replace(':', '').replace('+', '').replace('.', '')                   
            bits = bin(int(line))
            bits = bits.replace('0b', '')
            bits = int(bits, 2)
            numbers.append(bits)
        counter += 1
    f.close()
    return numbers


def climate(file):
    counter = 0
    bits = ""
    numbers = []

    f = open(file, "r+")
    lines = f.readlines()
    for line in lines:
        if counter > 0:
            line = line[30: len(line):] + line[len(line) + 1::]
            line = line.split(',')
            bits = bin(int(line[0])) + bin(int(line[1])) + bin(int(line[2]))
            bits = bits.replace('0b', '')
            bits = int(bits, 2)
            numbers.append(bits)
        counter += 1
    f.close()
    return numbers


def start_program():
    print("Introduzca el nombre del archivo: ")
    file = input()

    date = date_and_time(file)
    weather = climate(file)

    fl = open("climaEnteros.csv", "w")

    fl.write("DateAndTime, Climate\n")

    for i in range(len(date)):
        numbers = str(date[i]) + "," + str(weather[i]) + "\n"
        fl.write(numbers)
    fl.close()

    print("\nDone!")


start_program()
