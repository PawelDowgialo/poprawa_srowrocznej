class Albume:
    def __init__(self, band_name, title, number_of_songs, year, number_of_download):
        self.band_name = band_name
        self.title = title
        self.number_of_songs = number_of_songs
        self.year = year
        self.number_of_download = number_of_download

    def __str__(self):
        return f"{self.band_name, self.title, self.number_of_songs, self.year, self.number_of_download}"
def read_data_from_file():
    readed_data = []

    with open("Data.txt", "r") as file:
        lines = file.readlines()
        for line in range(int(len(lines)/6)+1):
            print(int(len(lines)/5))
            band_name = lines[0 + (line * 6)]
            title = lines[1 + (line * 6)]
            number_of_songs = lines[2 + (line * 6)]
            year = lines[3 + (line * 6)]
            number_of_download = lines[4 + (line * 6)]

            readed_data.append(Albume(band_name, title, number_of_songs, year, number_of_download))
    
    file.close()

    return readed_data

def show_data(readed_data):
    for i in readed_data:
        print(f"{i.band_name}{i.title}{i.number_of_songs}{i.year}{i.number_of_download}")

readed_data = read_data_from_file()
show_data(readed_data)