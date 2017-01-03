var mongoose = require('mongoose');
var Schema = mongoose.Schema;

var contactsSchema = new Schema({

    Id : Number, FirstName : String, LastName : String, UserId : String, 
CreatedOn: { type: Date, default: Date.now }} 
);
  



module.exports =  mongoose.model('Contact', contactsSchema);
