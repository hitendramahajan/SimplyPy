from PyPDF2 import PdfFileMerger
import requests
from PyPDF2 import PdfMerger

def fetch_data(url):
    try:
        response = requests.get(url)
        response.raise_for_status()  # Raise an exception for HTTP errors
        print("Data fetched successfully:")
        print(response.text[:200])  # Print the first 200 characters of the response
    except requests.RequestException as e:
        print(f"An error occurred: {e}")

def merge_pdf():
    merger = PdfFileMerger()
    print(merger.id_count)  # Note: This line will raise an AttributeError because id_count does not exist
    merger.close()

if __name__ == '__main__':
    # Example URL to fetch data from
    url = 'https://google.com'
    fetch_data(url)
    fetch_url(url)
    merge_pdf()
