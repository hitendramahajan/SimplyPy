from PyPDF2 import PdfFileMerger
from PyPDF2 import PdfMerger

def merge_pdf():
    merger = PdfFileMerger()
    print(merger.id_count)  # Note: This line will raise an AttributeError because id_count does not exist
    merger.close()

if __name__ == "__main__":
    merge_pdf()
