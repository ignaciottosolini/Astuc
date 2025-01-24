import cloudinary from "cloudinary-core";
function sha1(str) {
  return CryptoJS.SHA1(str).toString(CryptoJS.enc.Hex);
}
const cl = cloudinary.Cloudinary.new({ cloud_name: "ddqc2fdx4" });

const myconfig = cl.config({
  cloud_name: "ddqc2fdx4",
  api_key: "198172555659485",
  api_secret: "HveSFxQnj_zsGxqwRJCy9tC3cwA",
  secure: true,
});
const url =
  "https://api.cloudinary.com/v1_1/" + myconfig.cloud_name + "/auto/upload";

const timestamp = Math.round(new Date().getTime() / 1000);

const paramsToSign = {
  timestamp: timestamp,
  eager: "c_pad,h_300,w_400|c_crop,h_200,w_260"
};

const sortedParams = Object.keys(paramsToSign).sort().map(key => `${key}=${paramsToSign[key]}`).join('&');

const stringToSign = `${sortedParams}${myconfig.api_secret}`;

const signature = sha1(stringToSign);

export async function subirImagen(imagen) {
  const formData = new FormData();
  formData.append("file", imagen);
  formData.append("api_key", myconfig.api_key);
  formData.append("timestamp", timestamp);
  formData.append("signature", signature);
  formData.append("eager", "c_pad,h_300,w_400|c_crop,h_200,w_260");

  try {
    return await fetch(url, {
      method: "POST",
      body: formData,
    })
      .then((response) => {
        return response.text();
      })
      .then((data) => {
        const res = JSON.parse(data)
        // //.log(res.url)
        return res.url
      });
  } catch (error) {
    //.error(error);
    throw error;
  }
}
