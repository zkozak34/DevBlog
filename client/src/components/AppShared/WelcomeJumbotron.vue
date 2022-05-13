<template>
  <!-- Jumbotron -->
  <div id="jumbotron-area" class="my-2 py-4 bg-white">
    <div class="jumbotron text-center">
      <span class="display-4" id="typed">Hello World!</span>
      <p class="lead px-2">
        Hello World! ile başlayan yazılım öğrenme serüvenimde öğrendiklerimi paylaştığım sayfama hoş geldin.<br />Olumlu veya olumsuz bütün
        yorumlarını bekliyorum. Ayrıca önerilerini aşağıda ki buton aracılığıyla iletebilirsin.<br />
        Tekrardan Hello World!
      </p>
      <hr class="my-4" />
      <button type="button" class="btn btn-outline-dark" data-bs-toggle="modal" data-bs-target="#mySuggestForm">Öneride bulun</button>
      <div class="modal fade" id="mySuggestForm" tabindex="-1" aria-labelledby="suggestForm" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered text-start">
          <div class="modal-content">
            <div class="modal-header">
              <h5 class="modal-title" id="suggestForm">Öneride bulun</h5>
              <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
              <form>
                <div class="mb-3">
                  <label for="suggestFullName" class="form-label">Ad ve Soyad</label>
                  <input type="text" class="form-control" id="suggestFullName" aria-describedby="Ad ve Soyad" />
                </div>
                <div class="mb-3">
                  <label for="suggestEmail" class="form-label">E-Posta</label>
                  <input type="email" class="form-control" id="suggestEmail" />
                  <div id="suggestEmail" class="form-text">E-posta adresini cevap verebilmek için istiyorum. Kimseyle paylaşılmayacaktır.</div>
                </div>
                <div class="mb-3">
                  <label for="suggestMessage" class="form-label">Mesaj</label>
                  <textarea type="textarea" class="form-control" id="suggestMessage" rows="5"></textarea>
                </div>
              </form>
            </div>
            <div class="modal-footer">
              <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Kapat</button>
              <button type="button" class="btn btn-primary">Gönder</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <!-- Jumbotron -->
</template>
