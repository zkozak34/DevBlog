<template>
  <app-body>
    <div class="about-detail bg-white my-3 p-5 bg-white">
      <div class="about-title">
        <h1 class="display-5 fw-bold">Hakkımda</h1>
      </div>
      <div class="about-content">
        <p>Şu an bulunduğunuz bu websitesi <strong>Zeynel KOZAK (ZKDev)</strong> tarafından hazırlanmıştır.</p>
        <p>
          Frontend tarafından <strong>VueJS</strong> ve Backend tarafında ise <strong>.NET 6</strong> ile geliştirmeye devam ettiğim bu projemde
          yazılım öğrenim sürecinde edimdiği bilgileri paylaşıyorum.
        </p>
        <p>Peki Zeynel KOZAK kim?</p>
        <p>
          24 yaşında olup Selçuk Üniversitesi İşletme bölümünden mezun olmuş ve ardından Anadolu Üniversitesi Bilgisayar Programcılığı bölümüne
          başlamıştır. Askerlik hizmeti tamamlamasının hemen ardından proje geliştirmeye başlamış ve ilk yayına aldığı projesi de bu blog olmuştur.
          Herkes gibi Hello World! diyerek başladığı bu yolculuğunda ağırlıklı olarak backend üzerine kendini geliştirmeye devam etmektedir.
        </p>
        <p><strong>E-Posta :</strong> zeynel.kozak@outlook.com</p>
        <div>
          <p>
            <strong>Linkedin : </strong>
            <a href="https://www.linkedin.com/in/zeynel-kozak" style="text-decoration: none">https://www.linkedin.com/in/zeynel-kozak</a>
          </p>
        </div>
      </div>
    </div>
  </app-body>
</template>
<script>
import AppBody from "@/components/AppShared/AppBody/AppBody.vue";
export default {
  components: {
    AppBody,
  },
};
</script>
