import moment from "moment";
moment.locale(/*navigator.locale*/ "tr-TR");
export default {
  methods: {
    convertDate(date) {
      return moment(date).format("DD MMMM YYYY");
    },
  },
};
